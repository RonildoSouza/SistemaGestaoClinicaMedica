using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public interface IServicoLeituraBase<TId, TSaidaDTO>
    {
        Task<TSaidaDTO> GetAsync(TId id);
        Task<List<TSaidaDTO>> GetAsync();
    }
}
