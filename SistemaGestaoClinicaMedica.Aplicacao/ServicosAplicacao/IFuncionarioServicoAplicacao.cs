using SistemaGestaoClinicaMedica.Servico.Api.DTOS;
using System;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public interface IFuncionarioServicoAplicacao
    {
        LoginSaidaDTO Autorizar(LoginEntradaDTO loginEntradaDTO);
        //void Criar();
        //void Atualizar();
        dynamic Obter(Guid id);
        IList<dynamic> ObterTodos(bool ativos = true);
        void Deletar(Guid id);
    }
}
