using Microsoft.Extensions.Configuration;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using System;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public class ConsultaServico : ServicoBase<ConsultaDTO, Guid>, IConsultaServico
    {
        protected override string EndPoint => "consultas";

        public ConsultaServico(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
