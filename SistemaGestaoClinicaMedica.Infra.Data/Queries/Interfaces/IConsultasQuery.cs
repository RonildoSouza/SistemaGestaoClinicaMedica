using SistemaGestaoClinicaMedica.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Infra.Data.Queries
{
    public interface IConsultasQuery : IQueryBase<Consulta>
    {
        Consulta ObterComFiltros(Guid id, bool comExames, bool comAtestados);
        IList<Consulta> ObterTudoComFiltros(DateTime dataInicio, DateTime dataFim, string busca, IEnumerable<EStatusConsulta> status, Guid? medicoId = null);
    }
}
