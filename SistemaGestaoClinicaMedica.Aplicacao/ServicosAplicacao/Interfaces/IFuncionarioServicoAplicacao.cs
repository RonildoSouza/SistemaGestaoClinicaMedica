using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Funcionario;
using System;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public interface IFuncionarioServicoAplicacao : IServicoAplicacaoBase<FuncionarioSaidaDTO, FuncionarioEntradaDTO, Guid>
    {
        IList<FuncionarioSaidaDTO> ObterTudo(bool ativo);
    }
}
