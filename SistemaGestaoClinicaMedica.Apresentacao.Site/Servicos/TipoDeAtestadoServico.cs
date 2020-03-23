using Microsoft.Extensions.Configuration;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using System;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public class TipoDeAtestadoServico : ServicoBaseLeitura<TipoDeAtestadoDTO, string>, ITipoDeAtestadoServico
    {
        protected override string EndPoint => "tiposdeatestados";

        public TipoDeAtestadoServico(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
