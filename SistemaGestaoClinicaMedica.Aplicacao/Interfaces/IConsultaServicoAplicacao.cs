using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using System;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public interface IConsultaServicoAplicacao : IServicoAplicacaoBase<ConsultaDTO, Guid>
    {
        ConsultaDTO Obter(Guid id, bool comExames, bool comAtestados);
        IList<ConsultaDTO> ObterTudo(DateTime dataInicio, DateTime dataFim, string busca, string status, Guid? medicoId = null);
        void AlterarStatus(Guid id, StatusConsultaDTO statusConsulta);
        ConsultaDTO ObterPorCodigo(string codigo);
        IList<Tuple<string, int>> ObterTotalConsultasPorEspecialidade(DateTime dataInicio, DateTime dataFim);
        IList<Tuple<string, int>> ObterTotalConsultasPorMes(DateTime dataInicio, DateTime dataFim);
        IList<Tuple<string, int>> ObterTotalConsultasPorSexoPaciente(DateTime dataInicio, DateTime dataFim);
        IList<Tuple<int, int>> ObterTotalConsultasPorIdadePaciente(DateTime dataInicio, DateTime dataFim);
    }
}
