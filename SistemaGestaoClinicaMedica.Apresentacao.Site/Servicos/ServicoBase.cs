using Microsoft.Extensions.Configuration;
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
        public ServicoBase(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<HttpResponseMessage> PostAsync(TDTO dto)
        {
            var jsonString = JsonConvert.SerializeObject(dto);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            return await HttpClient.PostAsync(RequestUri, content);
        }

        public async Task<HttpResponseMessage> PutAsync(TId id, TDTO dto)
        {
            var jsonString = JsonConvert.SerializeObject(dto);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            return await HttpClient.PutAsync($"{RequestUri}/{id}", content);
        }

        public async Task<HttpResponseMessage> DeleteAsync(TId id)
        {
            return await HttpClient.DeleteAsync($"{RequestUri}/{id}");
        }
    }
}
