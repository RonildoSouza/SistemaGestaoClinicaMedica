using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using System;
using System.Linq;

namespace SistemaGestaoClinicaMedica.Infra.Data.Servicos
{
    public sealed class FuncionarioServico : ServicoBase<Guid, Funcionario>, IFuncionarioServico
    {
        public FuncionarioServico(ContextoBancoDados contextoBancoDados) : base(contextoBancoDados)
        {
        }

        public Funcionario Autorizar(string email, string senha)
        {
            return ContextoBancoDados.FuncionariosQuery.Autorizar(email, senha);
        }

        public void Deletar(Guid id)
        {
            var funcionario = ContextoBancoDados.Funcionarios.Find(id);

            if (funcionario == null)
                return;

            funcionario.Ativo = false;
            ContextoBancoDados.SaveChanges();
        }

        public IQueryable<Funcionario> ObterTudo(bool ativo = true)
        {
            return ContextoBancoDados.FuncionariosQuery.ObterTudo(ativo);
        }
    }
}
