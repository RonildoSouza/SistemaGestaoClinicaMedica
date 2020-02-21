using SistemaGestaoClinicaMedica.Dominio.Entidades;
using System.Linq;

namespace SistemaGestaoClinicaMedica.Infra.Data.Queries
{
    public interface IFuncionarioQueries : IQueriesBase
    {
        Funcionario Autorizar(string email, string senha);
        IQueryable<Funcionario> ObterTudoAtivoOuInativo(bool ativo = true);
    }
}
