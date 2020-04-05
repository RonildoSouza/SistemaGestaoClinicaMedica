using SistemaGestaoClinicaMedica.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Infra.Data.Queries
{
    public interface IExamesQuery : IQueryBase<Exame>
    {
        Exame ObterPorCodigo(string codigo);
        IList<Exame> ObterTudoPorConsultaId(Guid consultaId);
        IList<Exame> ObterTudoComFiltro(string busca, IEnumerable<EStatusExame> status, Guid? medicoId = null);
        IList<Tuple<string, int>> ObterTotalExames(DateTime dataInicio, DateTime dataFim);
    }
}
