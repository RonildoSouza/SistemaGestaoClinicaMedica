using Microsoft.Extensions.Configuration;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using System;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public class TipoDeExameServico : ServicoBaseLeitura<TipoDeExameDTO, Guid>, ITipoDeExameServico
    {
        protected override string EndPoint => "tiposdeexames";

        public TipoDeExameServico(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
