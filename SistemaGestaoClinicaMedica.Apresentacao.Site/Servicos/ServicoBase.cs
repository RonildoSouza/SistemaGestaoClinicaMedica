using Newtonsoft.Json;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public abstract class ServicoBase<TDTO, TId> : ServicoBaseLeitura<TDTO, TId>, IServicoBase<TDTO, TId>
        where TDTO : IDTO<TId>
    {
        public ServicoBase(ApplicationState applicationState) : base(applicationState) { }

        public virtual async Task<HttpResponseMessage> PostAsync(TDTO dto)
        {
            var jsonString = JsonConvert.SerializeObject(dto);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            return await ApplicationState.HttpClient.PostAsync(ApiEndPoint, content);
        }

        public virtual async Task<HttpResponseMessage> PutAsync(TId id, TDTO dto)
        {
            var jsonString = JsonConvert.SerializeObject(dto);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            return await ApplicationState.HttpClient.PutAsync($"{ApiEndPoint}/{id}", content);
        }

        public virtual async Task<HttpResponseMessage> DeleteAsync(TId id)
        {
            return await ApplicationState.HttpClient.DeleteAsync($"{ApiEndPoint}/{id}");
        }
    }
}
