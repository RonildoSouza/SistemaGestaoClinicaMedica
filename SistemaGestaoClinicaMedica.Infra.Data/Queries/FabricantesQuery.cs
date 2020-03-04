using SistemaGestaoClinicaMedica.Dominio.Entidades;
using System.Linq;

namespace SistemaGestaoClinicaMedica.Infra.Data.Queries
{
    public class FabricantesQuery : QueryBase, IFabricantesQuery
    {
        public IQueryable<Fabricante> ObterTudo(string nome)
        {
            var fabricantes = ContextoBancoDados.Fabricantes.OrderBy(_ => _.Nome).AsQueryable();

            if (!string.IsNullOrEmpty(nome))
                fabricantes = fabricantes.Where(_ => _.Nome.Contains(nome));

            return fabricantes;
        }
    }
}
