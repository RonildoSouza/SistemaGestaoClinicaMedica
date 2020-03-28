using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public interface IAtestadosServico : IServicoBase<AtestadoDTO, Guid>
    {
        Task<List<AtestadoDTO>> GetPorConsultaAsync(Guid consultaId);
    }
}
