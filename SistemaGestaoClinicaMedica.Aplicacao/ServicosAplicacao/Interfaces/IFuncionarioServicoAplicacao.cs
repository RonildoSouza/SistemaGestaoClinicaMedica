using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using System;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public interface IFuncionarioServicoAplicacao : IServicoAplicacaoBase<FuncionarioDTO, Guid>
    {
        IList<FuncionarioDTO> ObterTudo(bool ativo);
    }
}
