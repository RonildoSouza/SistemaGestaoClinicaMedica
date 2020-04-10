using Microsoft.EntityFrameworkCore;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace SistemaGestaoClinicaMedica.Infra.Data.Queries
{
    public class UsuariosQuery : QueryBase<Usuario>, IUsuariosQuery
    {
        public UsuariosQuery(ContextoBancoDados contextoBancoDados) : base(contextoBancoDados)
        {
        }

        public Usuario Autorizar(string email, string senha)
        {
            return Entidades.Include(_ => _.Cargo)
                            .FirstOrDefault(_ => _.Email.ToLower() == email.ToLower() && _.Senha == senha && _.Ativo);
        }

        public Usuario ObterPorEmail(string email)
        {
            return Entidades.FirstOrDefault(_ => _.Email.ToLower() == email.ToLower());
        }

        public IList<Usuario> ObterTudoComFiltros(string busca, bool ativo = true)
        {
            var usuarios = Entidades.Include(_ => _.Cargo)
                            .Where(_ => _.Ativo == ativo)
                            .Where(_ => _.Id != Usuario.SuperUsuarioId)
                            .OrderBy(_ => _.Nome)
                            .ToList();

            if (!string.IsNullOrEmpty(busca))
                usuarios = usuarios.Where(_ => _.Nome.ToLowerContains(busca)
                                            || _.Email.ToLowerContains(busca)).ToList();

            return usuarios;
        }
    }
}
