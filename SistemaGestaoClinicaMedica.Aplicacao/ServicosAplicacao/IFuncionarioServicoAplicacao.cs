using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Funcionario;
using System;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public interface IFuncionarioServicoAplicacao
    {
        FuncionarioSaidaDTO Salvar(FuncionarioEntradaDTO funcionarioEntradaDTO);
        FuncionarioSaidaDTO Obter(Guid id);
        IList<FuncionarioSaidaDTO> ObterTodos(bool ativos = true);
        void Deletar(Guid id);
    }
}
