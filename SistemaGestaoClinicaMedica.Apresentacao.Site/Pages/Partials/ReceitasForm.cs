using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using SistemaGestaoClinicaMedica.Apresentacao.Site.Constantes;
using SistemaGestaoClinicaMedica.Apresentacao.Site.Extensions;
using SistemaGestaoClinicaMedica.Apresentacao.Site.Modelo;
using SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos;
using SistemaGestaoClinicaMedica.Dominio.Documentos;
using SistemaGestaoClinicaMedica.Dominio.Documentos.Modelo;
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
        private bool _desabilitaBotoes;

        [Parameter] public ConsultaDTO Consulta { get; set; }

        [Inject] private IJSRuntime JSRuntime { get; set; }
        [Inject] private IMedicamentosServico MedicamentosServico { get; set; }
        [Inject] private IConstroiDocumento ConstroiDocumento { get; set; }

        private List<MedicamentoDTO> Medicamentos { get; set; } = new List<MedicamentoDTO>();
        protected override string AposSalvarRetonarPara => $"consultas/{Consulta.Id}#receitas";

        protected async override Task OnParametersSetAsync()
        {
            Medicamentos = await MedicamentosServico.GetPorNomeAsync("a");
            _dto.ConsultaId = Consulta.Id;

            if (Consulta.Receita != null && Consulta.Receita.Id != Guid.Empty)
            {
                Id = Consulta.Receita.Id;
                _dto = Consulta.Receita;
            }

            _desabilitaBotoes = Consulta.StatusConsultaId == StatusConsultaConst.Concluida || Consulta.StatusConsultaId == StatusConsultaConst.Cancelada;
        }

        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);

            var dotNetReference = DotNetObjectReference.Create(this);
            await JSRuntime.InvokeVoidAsync("select2JsInterop.startup", "#medicamentos", dotNetReference, nameof(SelecionaMedicamento));
        }

        protected async override Task<bool> Salvar(EditContext editContext)
        {
            if (!_desabilitaBotoes && !_dto.ReceitaMedicamentos.Any(_ => _.Ativo))
            {
                ToastService.ShowInfo("Você precisa selecionar adicionar um ou mais medicamentos!");
                return false;
            }

            var result = true;

            if (!_desabilitaBotoes)
                result = await base.Salvar(editContext);

            if (result)
            {
                if (string.IsNullOrEmpty(_dto?.Observacao?.Trim()))
                {
                    ToastService.ShowInfo("Não existe nenhuma informação para ser impressa!");
                    return false;
                }

                await JSRuntime.PrintContentAsync("receita-observacao");
            }

            return result;
        }

        private void ConstroiObservacao()
        {
            var medicamentosStringBuilder = new StringBuilder();
            _medicamentosSelecionados = _medicamentosSelecionados.OrderBy(_ => _).ToList();

            for (int i = 0; i < _medicamentosSelecionados.Count; i++)
                medicamentosStringBuilder.AppendLine($"{i + 1}) {_medicamentosSelecionados[i]}\n    - ");

            var receitaTemplate = new ReceitaTemplate(
                Consulta.Codigo,
                Consulta.Paciente.Nome,
                Consulta.Paciente.DataNascimento.ToShortDateString(),
                Consulta.Paciente.NomeDaMae,
                Consulta.Paciente.Sexo,
                Consulta.Medico.Nome,
                Consulta.Medico.CRM,
                medicamentosStringBuilder.ToString());

            _dto.Observacao = ConstroiDocumento.ConstroiTemplate(receitaTemplate);
            StateHasChanged();
        }

        [JSInvokable]
        public void SelecionaMedicamento(Select2 select2)
        {
            if (!Guid.TryParse(select2.Id, out Guid medicamentoId))
                return;

            if (_dto.Id != Guid.Empty && _dto.ReceitaMedicamentos.Any())
                _medicamentosSelecionados = _dto.ReceitaMedicamentos.Select(_ => _.Medicamento?.NomeFabrica).ToList();

            if (_dto.ReceitaMedicamentos.Any(_ => _.MedicamentoId == medicamentoId))
            {
                var index = _dto.ReceitaMedicamentos.FindIndex(_ => _.MedicamentoId == medicamentoId);

                if (_dto.ReceitaMedicamentos[index].Id == Guid.Empty)
                {
                    _dto.ReceitaMedicamentos.RemoveAt(index);
                    _medicamentosSelecionados.Remove(select2.Text);
                }
                else
                {
                    _dto.ReceitaMedicamentos[index].Ativo = !_dto.ReceitaMedicamentos[index].Ativo;
                    var medicamentoInativo = _dto.ReceitaMedicamentos.Where(_ => !_.Ativo).Select(_ => _.Medicamento?.NomeFabrica).ToList();

                    foreach (var item in medicamentoInativo)
                        _medicamentosSelecionados.Remove(item);
                }
            }
            else
            {
                _dto.ReceitaMedicamentos.Add(new ReceitaMedicamentoDTO { MedicamentoId = medicamentoId, Ativo = true });
                _medicamentosSelecionados.Add(select2.Text);
            }

            ConstroiObservacao();
        }
    }
}
