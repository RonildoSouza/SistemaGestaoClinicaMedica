using Microsoft.EntityFrameworkCore;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using System.Linq;

namespace SistemaGestaoClinicaMedica.Infra.Data.Queries
{
    public class FuncionariosQuery : QueryBase, IFuncionariosQuery
    {
        public Funcionario Autorizar(string email, string senha)
        {
            return ContextoBancoDados.Funcionarios.Include(_ => _.Cargo)
                                                  .FirstOrDefault(_ => _.Email == email.ToLower() && _.Senha == senha && _.Ativo);
        }

        public IQueryable<Funcionario> ObterTudo(bool ativo = true)
        {
            return ContextoBancoDados.Funcionarios.Include(_ => _.Cargo)
                                                  .Where(_ => _.Ativo == ativo)
                                                  .OrderBy(_ => _.Nome)
                                                  .AsQueryable();
        }
    }
}
