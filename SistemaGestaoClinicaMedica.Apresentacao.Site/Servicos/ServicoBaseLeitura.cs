using Blazored.LocalStorage;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public abstract class ServicoBaseLeitura<TDTO, TId> : IServicoLeituraBase<TDTO, TId>
    {
        protected HttpClient HttpClient { get; private set; }
        protected Uri RequestUri { get; private set; }
        protected virtual string EndPoint => GetType().Name.Replace("Servico", string.Empty).ToLower();

        public ServicoBaseLeitura(IConfiguration configuration, ILocalStorageService localStorage)
        {
            ConfiguraHttpClient(configuration, localStorage);
        }

        public async Task<TDTO> GetAsync(TId id)
        {
            var response = await HttpClient.GetStringAsync($"{RequestUri}/{id}");
            return JsonToDTO<TDTO>(response);
        }

        public async Task<List<TDTO>> GetAsync()
        {
            var response = await HttpClient.GetStringAsync(RequestUri);
            return JsonToDTO<List<TDTO>>(response);
        }

        protected T JsonToDTO<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        private void ConfiguraHttpClient(IConfiguration configuration, ILocalStorageService localStorage)
        {
            var apiUrlBase = configuration.GetValue<string>("ApiUrlBase");
            Uri.TryCreate($"{apiUrlBase}/{EndPoint}", UriKind.Absolute, out Uri uri);
            RequestUri = uri;

            if (RequestUri == null)
                throw new Exception($"Não foi possível criar a URI com a URL: {apiUrlBase}/{EndPoint}");

            var token = localStorage.GetItemAsync<string>(LoginServico.ChaveLocalStorage).Result;

            HttpClient = new HttpClient();
            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
    }
}
