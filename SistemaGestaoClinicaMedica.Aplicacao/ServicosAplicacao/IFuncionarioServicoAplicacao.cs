using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Funcionario;
using System;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public interface IFuncionarioServicoAplicacao
    {
        void Salvar(FuncionarioEntradaDTO funcionarioEntradaDTO);
        dynamic Obter(Guid id);
        IList<dynamic> ObterTodos(bool ativos = true);
        void Deletar(Guid id);
    }
}
