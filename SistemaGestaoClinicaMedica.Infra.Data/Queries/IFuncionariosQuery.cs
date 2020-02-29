using SistemaGestaoClinicaMedica.Dominio.Entidades;
using System.Linq;

namespace SistemaGestaoClinicaMedica.Infra.Data.Queries
{
    public interface IFuncionariosQuery : IQueryBase
    {
        Funcionario Autorizar(string email, string senha);
        IQueryable<Funcionario> ObterTudo(bool ativo = true);
    }
}
