using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Consulta;
using System;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public interface IConsultaServicoAplicacao : IServicoAplicacaoBase<ConsultaSaidaDTO, ConsultaEntradaDTO, Guid>
    {
        ConsultaSaidaDTO Obter(Guid id, bool comExames, bool comAtestados);
        IList<ConsultaSaidaDTO> ObterTudo(DateTime dataInicio, DateTime dataFim, string busca, string status);
    }
}
