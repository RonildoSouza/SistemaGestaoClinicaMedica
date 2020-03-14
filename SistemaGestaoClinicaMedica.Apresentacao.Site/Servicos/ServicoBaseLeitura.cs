using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public abstract class ServicoBaseLeitura<TId, TSaidaDTO> : IServicoLeituraBase<TId, TSaidaDTO>
    {
        protected HttpClient HttpClient { get; private set; }
        protected string ApiUrlBase { get; private set; }
        protected Uri RequestUri { get; private set; }
        protected abstract string EndPoint { get; }

        public ServicoBaseLeitura(IConfiguration configuration)
        {
            ConfiguraHttpClient(configuration);
        }

        public async Task<TSaidaDTO> GetAsync(TId id)
        {
            var response = await HttpClient.GetStringAsync($"{RequestUri}/{id}");
            return JsonToDTO<TSaidaDTO>(response);
        }

        public async Task<List<TSaidaDTO>> GetAsync()
        {
            var response = await HttpClient.GetStringAsync(RequestUri);
            return JsonToDTO<List<TSaidaDTO>>(response);
        }

        protected T JsonToDTO<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        private void ConfiguraHttpClient(IConfiguration configuration)
        {
            ApiUrlBase = configuration.GetValue<string>("ApiUrlBase");
            Uri.TryCreate($"{ApiUrlBase}/{EndPoint}", UriKind.Absolute, out Uri uri);
            RequestUri = uri;

            if (RequestUri == null)
                throw new Exception($"Não foi possível criar a URI com a URL: {ApiUrlBase}/{EndPoint}");

            HttpClient = new HttpClient();
            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjcyNzA1NTBGLTZCMTgtNDFFMi05ODE0LTdERTk3QjhEOTY2QSB8IFNVUEVSIFVTVcOBUklPIiwianRpIjoiZjM4NzAyYTdmNDZmNGU0MGI0ZDU2NmIwYjc0YzFhNTciLCJEYXRhIjoie1wiSWRcIjpcIjcyNzA1NTBmLTZiMTgtNDFlMi05ODE0LTdkZTk3YjhkOTY2YVwiLFwiTm9tZVwiOlwiU3VwZXIgVXN1w6FyaW9cIixcIkNhcmdvSWRcIjpcIkFkbWluaXN0cmFkb3JcIixcIkVtYWlsXCI6XCJhZG1pbmlzdHJhZG9yQGVtYWlsLmNvbVwifSIsInJvbGUiOiJBZG1pbmlzdHJhZG9yIiwibmJmIjoxNTg0MjA2ODg2LCJleHAiOjE1OTUwMDY4ODYsImlhdCI6MTU4NDIwNjg4NiwiaXNzIjoiUjBOMUxEMCIsImF1ZCI6IlIwTjFMRDAifQ.klwDkf5bCwwYXBB7nKMRsp2RKMxyJzptHKj2PjxRmX0");
        }
    }
}
