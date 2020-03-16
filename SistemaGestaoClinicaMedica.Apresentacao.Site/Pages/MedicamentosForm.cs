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

        private MedicamentoDTO _medicamento = new MedicamentoDTO();
        private EditContext _editContext;

        protected override async Task OnParametersSetAsync()
        {
            if (Id != Guid.Empty)
                _medicamento = await MedicamentoServico.GetAsync(Id);

            //_editContext = new EditContext(_medicamento);
        }

        //protected override void OnInitialized()
        //{
        //    _editContext = new EditContext(_medicamento);
        //}

        private async Task Salvar()
        {
            //if (!_editContext.Validate())
            //    return;

            await MedicamentoServico.PostAsync(_medicamento);
        }
    }
}
