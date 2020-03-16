using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos;
using System;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Pages
{
    public partial class MedicamentosForm
    {
        [Parameter]
        public Guid Id { get; set; }

        [Inject]
        private IMedicamentoServico MedicamentoServico { get; set; }

        [Inject]
        private NavigationManager NavigationManager { get; set; }

        private MedicamentoDTO _medicamento = new MedicamentoDTO();

        protected override async Task OnParametersSetAsync()
        {
            if (Id != Guid.Empty)
                _medicamento = await MedicamentoServico.GetAsync(Id);
        }

        private async Task Salvar(EditContext editContext)
        {
            if (!editContext.Validate())
                return;

            await MedicamentoServico.PostAsync(_medicamento);

            NavigationManager.NavigateTo("medicamentos");
        }
    }
}
