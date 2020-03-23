using Microsoft.Extensions.Configuration;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public class StatusConsultaServico : ServicoBaseLeitura<StatusConsultaDTO, string>, IStatusConsultaServico
    {
        protected override string EndPoint => "statusconsultas";

        public StatusConsultaServico(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
