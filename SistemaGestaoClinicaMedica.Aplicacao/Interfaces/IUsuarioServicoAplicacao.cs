using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using System;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public interface IUsuarioServicoAplicacao : IServicoAplicacaoBase<UsuarioDTO, Guid>
    {
        IList<UsuarioDTO> ObterTudo(string busca, bool ativo);
    }
}
