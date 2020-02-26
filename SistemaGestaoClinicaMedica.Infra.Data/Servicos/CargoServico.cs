using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;

namespace SistemaGestaoClinicaMedica.Infra.Data.Servicos
{
    public sealed class CargoServico : ServicoBase<string, Cargo>, ICargoServico
    {
        public CargoServico(ContextoBancoDados contextoBancoDados) : base(contextoBancoDados)
        {
        }
    }
}
