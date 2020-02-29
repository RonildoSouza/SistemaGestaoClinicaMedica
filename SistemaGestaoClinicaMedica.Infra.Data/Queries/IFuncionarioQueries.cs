using SistemaGestaoClinicaMedica.Dominio.Entidades;
using System.Linq;

namespace SistemaGestaoClinicaMedica.Infra.Data.Queries
{
    public interface IFuncionarioQueries : IQueryBase
    {
        Funcionario Autorizar(string email, string senha);
        IQueryable<Funcionario> ObterTudoAtivoOuInativo(bool ativo = true);
    }
}
