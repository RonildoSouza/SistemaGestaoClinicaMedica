using SistemaGestaoClinicaMedica.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Infra.Data.Queries
{
    public interface IConsultasQuery : IQueryBase<Consulta>
    {
        Consulta Obter(Guid id, bool comExames, bool comAtestados);
        IList<Consulta> ObterTudo(DateTime dataInicio, DateTime dataFim, string busca, EStatusConsulta? status);
    }
}
