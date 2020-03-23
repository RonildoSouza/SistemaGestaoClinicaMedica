using Microsoft.Extensions.Configuration;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using System;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public class AtestadoServico : ServicoBase<AtestadoDTO, Guid>, IAtestadoServico
    {
        protected override string EndPoint => "atestados";

        public AtestadoServico(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
