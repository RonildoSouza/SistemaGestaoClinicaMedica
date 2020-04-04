using SistemaGestaoClinicaMedica.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Dominio.Servicos
{
    public interface IConsultaServico : IServicoBase<Guid, Consulta>
    {
        Consulta ObterComFiltros(Guid id, bool comExames, bool comAtestados);
        IList<Consulta> ObterTudoComFiltros(DateTime dataInicio, DateTime dataFim, string busca, IEnumerable<EStatusConsulta> status, Guid? medicoId = null);
        void AlterarStatus(Guid id, EStatusConsulta eStatusConsulta);
        Consulta ObterPorCodigo(string codigo);
        IList<Tuple<string, int>> ObterTotalConsultasPorEspecialidade(DateTime dataInicio, DateTime dataFim);
        IList<Tuple<string, int>> ObterTotalConsultasPorMes(DateTime dataInicio, DateTime dataFim);
        IList<Tuple<string, int>> ObterTotalConsultasPorSexoPaciente(DateTime dataInicio, DateTime dataFim);
        IList<Tuple<int, int>> ObterTotalConsultasPorIdadePaciente(DateTime dataInicio, DateTime dataFim);
    }
}
