using Microsoft.Extensions.Configuration;
using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Consulta;
using System;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public class ConsultaServico : ServicoBase<Guid, ConsultaSaidaDTO, ConsultaEntradaDTO>, IConsultaServico
    {
        protected override string EndPoint => "consultas";

        public ConsultaServico(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
