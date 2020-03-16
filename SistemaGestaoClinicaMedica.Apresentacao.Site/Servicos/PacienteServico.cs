using Microsoft.Extensions.Configuration;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using System;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public class PacienteServico : ServicoBase<PacienteDTO, Guid>, IPacienteServico
    {
        protected override string EndPoint => "pacientes";

        public PacienteServico(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
