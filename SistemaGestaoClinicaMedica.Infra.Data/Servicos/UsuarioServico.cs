using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using SistemaGestaoClinicaMedica.Infra.Data.Queries;
using System;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Infra.Data.Servicos
{
    public sealed class UsuarioServico : ServicoBase<Guid, Usuario>, IUsuarioServico
    {
        private readonly IUsuariosQuery _usuariosQuery;

        public UsuarioServico(ContextoBancoDados contextoBancoDados, IUsuariosQuery usuariosQuery) : base(contextoBancoDados)
        {
            _usuariosQuery = usuariosQuery;
        }

        public Usuario Autorizar(string email, string senha)
        {
            return _usuariosQuery.Autorizar(email, senha);
        }

        public override void Deletar(Guid id)
        {
            var usuario = Entidades.Find(id);

            if (usuario == null)
                return;

            usuario.Ativo = false;
            ContextoBancoDados.SaveChanges();
        }

        public IList<Usuario> ObterTudoComFiltros(string busca, bool ativo)
        {
            return _usuariosQuery.ObterTudoComFiltros(busca, ativo);
        }
    }
}
