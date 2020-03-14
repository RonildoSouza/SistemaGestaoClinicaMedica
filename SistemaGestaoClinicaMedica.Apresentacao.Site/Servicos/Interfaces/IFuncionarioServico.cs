using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Funcionario;
using System;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public interface IFuncionarioServico : IServicoBase<Guid, FuncionarioSaidaDTO, FuncionarioEntradaDTO>
    {
    }
}
