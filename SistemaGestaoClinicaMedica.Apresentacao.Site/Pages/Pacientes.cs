using Microsoft.AspNetCore.Components;
using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Paciente;
using SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Pages
{
    public partial class Pacientes
    {
        [Inject]
        private IPacienteServico PacienteServico { get; set; }

        private List<PacienteSaidaDTO> pacientes;

        protected override async Task OnInitializedAsync()
        {
            pacientes = await PacienteServico.GetAsync();
        }
    }
}
