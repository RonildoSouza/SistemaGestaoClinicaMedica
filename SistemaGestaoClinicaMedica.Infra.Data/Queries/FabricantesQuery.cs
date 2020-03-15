using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Extensions;
using System.Linq;

namespace SistemaGestaoClinicaMedica.Infra.Data.Queries
{
    public class FabricantesQuery : QueryBase<Fabricante>, IFabricantesQuery
    {
        public FabricantesQuery(ContextoBancoDados contextoBancoDados) : base(contextoBancoDados)
        {
        }

        public Fabricante Obter(string nome)
        {
            if (string.IsNullOrEmpty(nome))
                return null;

            return Entidades.FirstOrDefault(_ => _.Nome.ToLowerContains(nome));
        }
    }
}
