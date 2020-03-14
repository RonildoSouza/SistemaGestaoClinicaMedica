using Microsoft.Extensions.Configuration;
using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Funcionario;
using System;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public class FuncionarioServico : ServicoBase<Guid, FuncionarioSaidaDTO, FuncionarioEntradaDTO>, IFuncionarioServico
    {
        protected override string EndPoint => "funcionarios";

        public FuncionarioServico(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
