using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public interface IConsultaServico : IServicoBase<ConsultaDTO, Guid>
    {
        Task<List<ConsultaDTO>> GetTudoComFiltrosAsync(DateTime dataInicio, DateTime dataFim, string busca, string status, Guid? medicoId = null);
    }
}
