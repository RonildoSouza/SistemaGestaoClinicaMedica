using Microsoft.EntityFrameworkCore;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using System.Linq;

namespace SistemaGestaoClinicaMedica.Infra.Data.Queries
{
    public class FuncionarioQueries : QueryBase, IFuncionarioQueries
    {
        public Funcionario Autorizar(string email, string senha)
        {
            return ContextoBancoDados.Funcionarios.Include(_ => _.Cargo)
                                                  .FirstOrDefault(_ => _.Email == email.ToLower() && _.Senha == senha && _.Ativo);
        }

        public IQueryable<Funcionario> ObterTudoAtivoOuInativo(bool ativo = true)
        {
            return ContextoBancoDados.Funcionarios.Include(_ => _.Cargo)
                                                  .Where(_ => _.Ativo == ativo)
                                                  .AsQueryable();
        }
    }
}
