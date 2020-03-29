using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using System.Linq;

namespace SistemaGestaoClinicaMedica.Infra.Data.Servicos
{
    public sealed class CargoServico : ServicoBase<string, Cargo>, ICargoServico
    {
        public CargoServico(ContextoBancoDados contextoBancoDados) : base(contextoBancoDados)
        {
        }

        public override IQueryable<Cargo> ObterTudo(bool asNoTracking = false)
        {
            return Entidades.OrderBy(_ => _.Nome);
        }
    }
}
