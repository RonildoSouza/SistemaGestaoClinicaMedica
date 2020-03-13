using SistemaGestaoClinicaMedica.Dominio.Entidades;
using System;

namespace SistemaGestaoClinicaMedica.Infra.Data.Queries
{
    public interface IReceitasQuery : IQueryBase<Receita>
    {
        Receita ObterPorConsultaId(Guid id);
    }
}
