using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Funcionario;
using System;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public interface IFuncionarioServicoAplicacao
    {
        FuncionarioSaidaDTO Salvar(FuncionarioEntradaDTO funcionarioEntradaDTO, Guid id = default);
        FuncionarioSaidaDTO Obter(Guid id);
        IList<FuncionarioSaidaDTO> ObterTudo(bool ativo = true);
        void Deletar(Guid id);
    }
}
