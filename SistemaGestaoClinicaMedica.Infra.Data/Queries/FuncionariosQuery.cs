using Microsoft.EntityFrameworkCore;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace SistemaGestaoClinicaMedica.Infra.Data.Queries
{
    public class FuncionariosQuery : QueryBase<Funcionario>, IFuncionariosQuery
    {
        public FuncionariosQuery(ContextoBancoDados contextoBancoDados) : base(contextoBancoDados)
        {
        }

        public Funcionario Autorizar(string email, string senha)
        {
            return Entidades.Include(_ => _.Cargo)
                            .FirstOrDefault(_ => _.Email.ToLower() == email.ToLower() && _.Senha == senha && _.Ativo);
        }

        public IList<Funcionario> ObterTudo(bool ativo = true)
        {
            return Entidades.Include(_ => _.Cargo)
                            .Where(_ => _.Ativo == ativo)
                            .OrderBy(_ => _.Nome)
                            .ToList();
        }
    }
}
