using SistemaGestaoClinicaMedica.Dominio.Entidades;
using System.Linq;

namespace SistemaGestaoClinicaMedica.Infra.Data.Queries
{
    public class FuncionarioQueries : QueriesBase, IFuncionarioQueries
    {
        public Funcionario Autorizar(string email, string senha)
        {
            return ContextoBancoDados.Funcionarios.FirstOrDefault(_ => _.Email == email.ToLower() && _.Senha == senha);
        }

        public IQueryable<Funcionario> ObterTudoAtivoOuInativo(bool ativo = true)
        {
            return ContextoBancoDados.Funcionarios.Where(_ => _.Ativo == ativo).AsQueryable();
        }
    }
}
