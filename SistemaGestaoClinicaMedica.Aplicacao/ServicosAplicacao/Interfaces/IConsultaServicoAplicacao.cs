using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Consulta;
using System;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public interface IConsultaServicoAplicacao : IServicoAplicacaoBase<ConsultaSaidaDTO, ConsultaEntradaDTO, Guid>
    {
        IList<ConsultaSaidaDTO> ObterTudo(DateTime dataInicio, DateTime dataFim, string busca, string status);
    }
}
