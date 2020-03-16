using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public interface IServicoLeituraBase<TDTO, TId>
    {
        Task<TDTO> GetAsync(TId id);
        Task<List<TDTO>> GetAsync();
    }
}
