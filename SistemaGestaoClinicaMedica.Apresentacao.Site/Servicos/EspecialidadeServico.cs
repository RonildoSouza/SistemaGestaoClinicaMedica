using Microsoft.Extensions.Configuration;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using System;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public class EspecialidadeServico : ServicoBaseLeitura<EspecialidadeDTO, Guid>, IEspecialidadeServico
    {
        protected override string EndPoint => "especialidades";

        public EspecialidadeServico(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
