using SistemaGestaoClinicaMedica.Dominio.Entidades;
using System.Linq;

namespace SistemaGestaoClinicaMedica.Infra.Data.Queries
{
    public interface IFabricantesQuery : IQueryBase
    {
        IQueryable<Fabricante> ObterTudo(string nome);
    }
}
