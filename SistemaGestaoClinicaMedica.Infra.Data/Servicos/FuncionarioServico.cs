using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using SistemaGestaoClinicaMedica.Infra.Data.Queries;
using System;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Infra.Data.Servicos
{
    public sealed class FuncionarioServico : ServicoBase<Guid, Funcionario>, IFuncionarioServico
    {
        private readonly IFuncionariosQuery _funcionariosQuery;

        public FuncionarioServico(ContextoBancoDados contextoBancoDados, IFuncionariosQuery funcionariosQuery) : base(contextoBancoDados)
        {
            _funcionariosQuery = funcionariosQuery;
        }

        public Funcionario Autorizar(string email, string senha)
        {
            return _funcionariosQuery.Autorizar(email, senha);
        }

        public override void Deletar(Guid id)
        {
            var funcionario = Entidades.Find(id);

            if (funcionario == null)
                return;

            funcionario.Ativo = false;
            ContextoBancoDados.SaveChanges();
        }

        public IList<Funcionario> ObterTudoComFiltros(bool ativo)
        {
            return _funcionariosQuery.ObterTudoComFiltros(ativo);
        }
    }
}
