using Microsoft.Extensions.Configuration;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using System;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public class FuncionarioServico : ServicoBase<FuncionarioDTO, Guid>, IFuncionarioServico
    {
        protected override string EndPoint => "funcionarios";

        public FuncionarioServico(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
