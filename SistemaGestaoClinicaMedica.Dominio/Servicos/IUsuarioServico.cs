using SistemaGestaoClinicaMedica.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Dominio.Servicos
{
    public interface IUsuarioServico : IServicoBase<Guid, Usuario>
    {
        Usuario Autorizar(string email, string senha);
        IList<Usuario> ObterTudoComFiltros(string busca, bool ativo);
    }
}
