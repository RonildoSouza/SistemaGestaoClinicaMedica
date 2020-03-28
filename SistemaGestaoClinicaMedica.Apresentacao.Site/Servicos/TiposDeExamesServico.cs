using Microsoft.Extensions.Configuration;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using System;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public class TiposDeExamesServico : ServicoBaseLeitura<TipoDeExameDTO, Guid>, ITiposDeExamesServico
    {
        public TiposDeExamesServico(IConfiguration configuration) : base(configuration) { }
    }
}
