using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using System;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public interface IReceitaServico : IServicoBase<ReceitaDTO, Guid>
    {
        Task<ReceitaDTO> GetPorConsultaAsync(Guid consultaId);
    }
}
