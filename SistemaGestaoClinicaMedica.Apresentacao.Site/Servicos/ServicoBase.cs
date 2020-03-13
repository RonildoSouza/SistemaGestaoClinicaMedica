using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public abstract class ServicoBase<TId, TSaidaDTO, TEntradaDTO> : ServicoBaseLeitura<TId, TSaidaDTO>, IServicoBase<TId, TSaidaDTO, TEntradaDTO>
    {
        public ServicoBase(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<HttpResponseMessage> PostAsync(TEntradaDTO dto)
        {
            var jsonString = JsonConvert.SerializeObject(dto);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            return await HttpClient.PostAsync(RequestUri, content);
        }

        public async Task<HttpResponseMessage> PutAsync(TId id, TEntradaDTO dto)
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
