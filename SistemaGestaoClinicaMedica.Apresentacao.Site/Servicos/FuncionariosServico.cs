using Microsoft.Extensions.Configuration;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using System;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public class FuncionariosServico : ServicoBase<FuncionarioDTO, Guid>, IFuncionariosServico
    {
        public FuncionariosServico(IConfiguration configuration) : base(configuration) { }
    }
}
