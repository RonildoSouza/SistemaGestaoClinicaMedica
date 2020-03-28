using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using SistemaGestaoClinicaMedica.Apresentacao.Site.Documentos;
using SistemaGestaoClinicaMedica.Apresentacao.Site.Documentos.Modelo;
using SistemaGestaoClinicaMedica.Apresentacao.Site.Modelo;
using SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Pages.Partials
{
    public partial class ReceitasForm
    {
        private List<string> _medicamentosSelecionados = new List<string>();

        [Parameter] public ConsultaDTO Consulta { get; set; }

        [Inject] private IJSRuntime JSRuntime { get; set; }
        [Inject] private IMedicamentosServico MedicamentosServico { get; set; }
        [Inject] private IConstroiDocumento ConstroiDocumento { get; set; }

        private List<MedicamentoDTO> Medicamentos { get; set; } = new List<MedicamentoDTO>();
        protected override string AposSalvarRetonarPara => $"consultas/{Consulta.Id}#receitas";

        protected async override Task OnParametersSetAsync()
        {
            Medicamentos = await MedicamentosServico.GetPorNomeAsync("a");

            if (Consulta.Receita != null && Consulta.Receita.Id != Guid.Empty)
                _dto = Consulta.Receita;
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

            if (_dto.Id != Guid.Empty && _dto.ReceitaMedicamentos.Any())
                _medicamentosSelecionados = _dto.ReceitaMedicamentos.Select(_ => _.Medicamento.NomeFabrica).ToList();

            if (_dto.ReceitaMedicamentos.Any(_ => _.MedicamentoId == medicamentoId))
            {
                var index = _dto.ReceitaMedicamentos.FindIndex(_ => _.MedicamentoId == medicamentoId);
                _dto.ReceitaMedicamentos.RemoveAt(index);
                _medicamentosSelecionados.Remove(select2.Text);
            }
            else
            {
                _dto.ReceitaMedicamentos.Add(new ReceitaMedicamentoDTO { MedicamentoId = medicamentoId });
                _medicamentosSelecionados.Add(select2.Text);
            }

            ConstroiObservacao();
        }

        private void ConstroiObservacao()
        {
            var medicamentosStringBuilder = new StringBuilder();

            for (int i = 0; i < _medicamentosSelecionados.Count; i++)
                medicamentosStringBuilder.AppendLine($"{i + 1}) {_medicamentosSelecionados[i]}\n\t- ");

            var receitaTemplate = new ReceitaTemplate(
                Consulta.Codigo,
                Consulta.Paciente.Nome,
                Consulta.Paciente.DataNascimento.ToShortDateString(),
                Consulta.Medico.Nome,
                Consulta.Medico.CRM,
                medicamentosStringBuilder.ToString());

            _dto.Observacao = ConstroiDocumento.ConstroiTemplate(receitaTemplate);
            StateHasChanged();
        }
    }
}
