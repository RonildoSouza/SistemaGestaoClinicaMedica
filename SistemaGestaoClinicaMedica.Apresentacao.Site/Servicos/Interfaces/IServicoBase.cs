using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using System.Net.Http;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public interface IServicoBase<TDTO, TId> : IServicoLeituraBase<TDTO, TId>
        where TDTO : IDTO<TId>
    {
        Task<HttpResponseMessage> PostAsync(TDTO dto);
        Task<HttpResponseMessage> PutAsync(TId id, TDTO dto);
        Task<HttpResponseMessage> DeleteAsync(TId id);
    }
}
