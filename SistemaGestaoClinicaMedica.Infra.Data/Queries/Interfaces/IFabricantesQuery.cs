using SistemaGestaoClinicaMedica.Dominio.Entidades;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Infra.Data.Queries
{
    public interface IFabricantesQuery : IQueryBase<Fabricante>
    {
        IEnumerable<Fabricante> ObterTudoPorNome(string nome);
        Fabricante ObterPorNome(string nome);
    }
}
