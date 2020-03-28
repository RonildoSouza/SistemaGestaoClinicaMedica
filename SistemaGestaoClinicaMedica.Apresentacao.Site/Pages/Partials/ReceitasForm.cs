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
        [Parameter] public ConsultaDTO Consulta { get; set; }

        [Inject] public IJSRuntime JSRuntime { get; set; }
        [Inject] public IMedicamentoServico MedicamentoServico { get; set; }
        [Inject] public IConstroiDocumento ConstroiDocumento { get; set; }

        public List<MedicamentoDTO> Medicamentos { get; set; } = new List<MedicamentoDTO>();

        protected override string AposSalvarRetonarPara => $"consultas/{Consulta.Id}#receitas";

        private List<string> _medicamentosSelecionados = new List<string>();


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
