using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace SistemaGestaoClinicaMedica.Infra.Data.Queries
{
    public class FabricantesQuery : QueryBase<Fabricante>, IFabricantesQuery
    {
        public FabricantesQuery(ContextoBancoDados contextoBancoDados) : base(contextoBancoDados)
        {
        }

        public IList<Fabricante> ObterTudo(string nome)
        {
            var fabricantes = Entidades.OrderBy(_ => _.Nome).ToList();

            if (!string.IsNullOrEmpty(nome))
                fabricantes = fabricantes.Where(_ => _.Nome.ToLowerContains(nome)).ToList();

            return fabricantes;
        }
    }
}
