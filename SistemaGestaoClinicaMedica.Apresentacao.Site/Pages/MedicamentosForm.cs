using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Medicamento;
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

        private MedicamentoEntradaDTO _medicamento = new MedicamentoEntradaDTO();
        private EditContext _editContext;

        //protected override async Task OnInitializedAsync()
        //{
        //    if (Id != Guid.Empty)
        //    {
        //        var medicamentoSaida = await MedicamentoServico.GetAsync(Id);
        //        _medicamento = new MedicamentoEntradaDTO
        //        {
        //            Id = medicamentoSaida.Id,
        //            Nome = medicamentoSaida.Nome,
        //            NomeFabrica = medicamentoSaida.NomeFabrica,
        //            Tarja = medicamentoSaida.Tarja,
        //            FabricanteNome = medicamentoSaida.FabricanteNome
        //        };
        //    }

        //    _editContext = new EditContext(_medicamento);
        //}

        protected override void OnInitialized()
        {
            if (Id != Guid.Empty)
            {
                //var medicamentoSaida = MedicamentoServico.GetAsync(Id).Result;
                _medicamento = new MedicamentoEntradaDTO
                {
                    //Id = medicamentoSaida.Id,
                    Nome = "Nome de TESTE1321321231",
                };
            }

            _editContext = new EditContext(_medicamento);
        }

        private async Task Salvar()
        {
            if (!_editContext.Validate())
                return;

            await MedicamentoServico.PostAsync(_medicamento);
        }
    }
}
