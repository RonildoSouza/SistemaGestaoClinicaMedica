using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using System;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public interface IExameServico : IServicoBase<ExameDTO, Guid>
    {
        Task<ExameDTO> GetPorCodigoAsync(string codigo);
    }
}
