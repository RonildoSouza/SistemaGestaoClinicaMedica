using Microsoft.AspNetCore.Components;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Pages
{
    public partial class Pacientes
    {
        [Inject]
        private IPacienteServico PacienteServico { get; set; }

        private List<PacienteDTO> pacientes;

        protected override async Task OnInitializedAsync()
        {
            pacientes = await PacienteServico.GetAsync();
        }
    }
}
