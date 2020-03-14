using Microsoft.Extensions.Configuration;
using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Paciente;
using System;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public class PacienteServico : ServicoBase<Guid, PacienteSaidaDTO, PacienteEntradaDTO>, IPacienteServico
    {
        protected override string EndPoint => "pacientes";

        public PacienteServico(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
