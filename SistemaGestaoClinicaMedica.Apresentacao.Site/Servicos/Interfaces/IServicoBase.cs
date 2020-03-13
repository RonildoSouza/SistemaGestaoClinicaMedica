using System.Net.Http;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public interface IServicoBase<TId, TSaidaDTO, TEntradaDTO> : IServicoLeituraBase<TId, TSaidaDTO>
    {
        Task<HttpResponseMessage> PostAsync(TEntradaDTO dto);
        Task<HttpResponseMessage> PutAsync(TId id, TEntradaDTO dto);
        Task<HttpResponseMessage> DeleteAsync(TId id);
    }
}
