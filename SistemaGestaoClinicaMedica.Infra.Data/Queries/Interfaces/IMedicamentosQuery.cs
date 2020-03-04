using SistemaGestaoClinicaMedica.Dominio.Entidades;
using System.Linq;

namespace SistemaGestaoClinicaMedica.Infra.Data.Queries
{
    public interface IMedicamentosQuery : IQueryBase
    {
        IQueryable<Medicamento> ObterTudo(string nome, bool ativo = true);
    }
}
