using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using SistemaGestaoClinicaMedica.Apresentacao.Site.Modelo;
using SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Pages.Partials
{
    public partial class ReceitasForm
    {
        [Parameter] public ConsultaDTO Consulta { get; set; }

        [Inject] public IJSRuntime JSRuntime { get; set; }
        [Inject] public IMedicamentoServico MedicamentoServico { get; set; }

        public List<MedicamentoDTO> Medicamentos { get; set; } = new List<MedicamentoDTO>();

        protected override string AposSalvarRetonarPara => $"consultas/{Consulta.Id}#receitas";

        protected async override Task OnParametersSetAsync()
        {
            Medicamentos = await MedicamentoServico.GetPorNomeAsync("a");

            _dto.ConsultaId = Consulta.Id;
            var receita = await HttpServico.GetPorConsultaAsync(Consulta.Id);

            if (receita != null)
            {
                Id = receita.Id;
                _dto = receita;
            }
        }

        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);

            var dotNetReference = DotNetObjectReference.Create(this);
            await JSRuntime.InvokeVoidAsync("select2JsInterop.startup", "#medicamentos", dotNetReference, nameof(SelecionaMedicamento));
        }

        [JSInvokable]
        public void SelecionaMedicamento(Select2 select2)
        {
            if (!Guid.TryParse(select2.Id, out Guid medicamentoId))
                return;

            if (_dto.ReceitaMedicamentos.Any(_ => _.MedicamentoId == medicamentoId))
            {
                var index = _dto.ReceitaMedicamentos.FindIndex(_ => _.MedicamentoId == medicamentoId);
                _dto.ReceitaMedicamentos.RemoveAt(index);
            }
            else
            {
                _dto.ReceitaMedicamentos.Add(new ReceitaMedicamentoDTO { MedicamentoId = medicamentoId });
            }
        }
    }
}
