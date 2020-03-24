using Microsoft.Extensions.Configuration;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using System;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public class ExameServico : ServicoBase<ExameDTO, Guid>, IExameServico
    {
        protected override string EndPoint => "exames";

        public ExameServico(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
