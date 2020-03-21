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

        public Fabricante ObterPorNome(string nome)
        {
            if (string.IsNullOrEmpty(nome))
                return null;

            return Entidades.ToList().FirstOrDefault(_ => _.Nome.ToLowerContains(nome));
        }
    }
}
