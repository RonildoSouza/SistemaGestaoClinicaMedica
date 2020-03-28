using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using System;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public interface IReceitasServico : IServicoBase<ReceitaDTO, Guid>
    {
        Task<ReceitaDTO> GetPorConsultaAsync(Guid consultaId);
    }
}
