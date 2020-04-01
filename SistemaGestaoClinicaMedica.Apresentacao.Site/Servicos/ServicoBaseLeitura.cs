using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public abstract class ServicoBaseLeitura<TDTO, TId> : IServicoLeituraBase<TDTO, TId>
    {
        protected virtual string ApiEndPoint => $"/api/{GetType().Name.Replace("Servico", string.Empty).ToLower()}";
        protected ApplicationState ApplicationState { get; private set; }

        protected ServicoBaseLeitura(ApplicationState applicationState)
        {
            ApplicationState = applicationState;
        }

        public async Task<TDTO> GetAsync(TId id)
        {
            var response = await ApplicationState.HttpClient.GetStringAsync($"{ApiEndPoint}/{id}");
            return JsonToDTO<TDTO>(response);
        }

        public async Task<List<TDTO>> GetAsync()
        {
            var response = await ApplicationState.HttpClient.GetStringAsync(ApiEndPoint);
            return JsonToDTO<List<TDTO>>(response);
        }

        protected T JsonToDTO<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
