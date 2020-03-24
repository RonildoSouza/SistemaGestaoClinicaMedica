using Microsoft.Extensions.Configuration;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public class StatusExameServico : ServicoBaseLeitura<StatusExameDTO, string>, IStatusExameServico
    {
        protected override string EndPoint => "statusexames";

        public StatusExameServico(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
