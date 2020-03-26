using Microsoft.EntityFrameworkCore;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaGestaoClinicaMedica.Infra.Data.Queries
{
    public class AtestadosQuery : QueryBase<Atestado>, IAtestadosQuery
    {
        public AtestadosQuery(ContextoBancoDados contextoBancoDados) : base(contextoBancoDados)
        {
        }

        public IList<Atestado> ObterTudoPorConsultaId(Guid consultaId)
        {
            return Entidades.Include(_ => _.TipoDeAtestado)
                            .Include(_ => _.Consulta)
                            .Where(_ => _.Consulta.Id == consultaId)
                            .ToList();
        }
    }
}
