using Microsoft.AspNetCore.Components;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Pages
{
    public partial class Medicamentos
    {
        [Inject]
        private IMedicamentoServico MedicamentoServico { get; set; }

        private List<MedicamentoDTO> medicamentos;

        protected override async Task OnInitializedAsync()
        {
            medicamentos = await MedicamentoServico.GetAsync();
        }
    }
}
