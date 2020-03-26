using SistemaGestaoClinicaMedica.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Infra.Data.Queries
{
    public interface IAtestadosQuery : IQueryBase<Atestado>
    {
        IList<Atestado> ObterTudoPorConsultaId(Guid consultaId);
    }
}
