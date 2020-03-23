using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using System;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public interface IConsultaServicoAplicacao : IServicoAplicacaoBase<ConsultaDTO, Guid>
    {
        ConsultaDTO Obter(Guid id, bool comExames, bool comAtestados);
        IList<ConsultaDTO> ObterTudo(DateTime dataInicio, DateTime dataFim, string busca, string status, Guid? medicoId = null);
    }
}
