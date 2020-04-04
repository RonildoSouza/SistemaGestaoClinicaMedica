using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using SistemaGestaoClinicaMedica.Apresentacao.Site.Constantes;
using SistemaGestaoClinicaMedica.Apresentacao.Site.Extensions;
using SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos;
using SistemaGestaoClinicaMedica.Dominio.Documentos;
using SistemaGestaoClinicaMedica.Dominio.Documentos.Modelo;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Pages
{
    public partial class AtestadosForm
    {
        private List<TipoDeAtestadoDTO> _tiposDeAtestados = new List<TipoDeAtestadoDTO>();
        private ConsultaDTO _consulta;

        [Parameter] public Guid ConsultaId { get; set; }

        [Inject] private IJSRuntime JSRuntime { get; set; }
        [Inject] private IConsultasServico ConsultasServico { get; set; }
        [Inject] private ITiposDeAtestadosServico TiposDeAtestadoServico { get; set; }
        [Inject] private IConstroiDocumento ConstroiDocumento { get; set; }

        protected async override Task OnInitializedAsync()
        {
            _tiposDeAtestados = await TiposDeAtestadoServico.GetAsync();
        }

        protected async override Task OnParametersSetAsync()
        {
            await base.OnParametersSetAsync();

            if (_dto.ConsultaId == Guid.Empty)
                _dto.ConsultaId = ConsultaId;

            _consulta = await ConsultasServico.GetAsync(ConsultaId);
        }

        protected async override Task<bool> Salvar(EditContext editContext)
        {
            var result = await base.Salvar(editContext);
            if (result)
                await JSRuntime.PrintContentAsync("atestado-observacao");

            return result;
        }

        private async Task SelecionaTipoDeAtestadoAsync(ChangeEventArgs args)
        {
            var tipoDeAtestadoId = args.Value.ToString();

            if (string.IsNullOrEmpty(tipoDeAtestadoId))
                return;

            var tipoDeAtestado = await TiposDeAtestadoServico.GetAsync(tipoDeAtestadoId);

            if (tipoDeAtestado == null)
                return;

            _dto.TipoDeAtestado.Id = tipoDeAtestadoId;

            var observacao = ConstroiDocumento.ConstroiTemplate(new AtestadoMedicoTemplate(
                    tipoDeAtestado.Nome,
                    _consulta.Paciente.Nome,
                    _consulta.Paciente.CPF,
                    _consulta.Medico.Nome,
                    _consulta.Medico.CRM,
                    tipoDeAtestadoId != TipoDeAtestadoConst.AtestadoDeSanidadeFisicaMental));

            if (tipoDeAtestadoId == TipoDeAtestadoConst.AtestadoDeAptidaoFisica)
            {
                observacao = ConstroiDocumento.ConstroiTemplate(new AtestadoAptidaoFisicaTemplate(
                    _consulta.Paciente.Nome,
                    _consulta.Paciente.CPF,
                    _consulta.Medico.Nome,
                    _consulta.Medico.CRM));
            }

            if (tipoDeAtestadoId == TipoDeAtestadoConst.AtestadoDeComparecimento)
            {
                observacao = ConstroiDocumento.ConstroiTemplate(new AtestadoComparecimentoTemplate(
                    _consulta.Paciente.Nome,
                    _consulta.Paciente.CPF,
                    _consulta.Medico.Nome,
                    _consulta.Medico.CRM));
            }

            _dto.Observacao = observacao;
            StateHasChanged();
        }
    }
}
