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
    public partial class ExamesForm
    {
        private List<TipoDeExameDTO> _tiposDeExames = new List<TipoDeExameDTO>();
        private ConsultaDTO consulta;
        private string _tipoDeExameId;

        [Parameter] public Guid ConsultaId { get; set; }

        [Inject] private IJSRuntime JSRuntime { get; set; }
        [Inject] private ITiposDeExamesServico TiposDeExamesServico { get; set; }
        [Inject] private IConsultasServico ConsultasServico { get; set; }
        [Inject] private IConstroiDocumento ConstroiDocumento { get; set; }

        protected async override Task OnInitializedAsync()
        {
            _tiposDeExames = await TiposDeExamesServico.GetAsync();
        }

        protected async override Task OnParametersSetAsync()
        {
            await base.OnParametersSetAsync();

            if (_dto.ConsultaId == Guid.Empty)
                _dto.ConsultaId = ConsultaId;

            if (_dto?.Id != Guid.Empty)
                _tipoDeExameId = _dto.TipoDeExame.Id.ToString();

            consulta = await ConsultasServico.GetAsync(ConsultaId);
        }

        protected async override Task<bool> Salvar(EditContext editContext)
        {
            if (string.IsNullOrEmpty(_tipoDeExameId))
                return false;

            _dto.StatusExame.Id = StatusExameConst.Pendente;
            _dto.TipoDeExame.Id = Guid.Parse(_tipoDeExameId);

            var result = await base.Salvar(editContext);
            if (result)
            {
                await JSRuntime.PrintContentAsync("exame-observacao");
                await ConsultasServico.PutAlterarStatusAsync(_dto.ConsultaId, StatusConsultaConst.AguardandoRetorno);
            }

            return result;
        }

        private async Task SelecionaTipoDeExameAsync(ChangeEventArgs args)
        {
            _tipoDeExameId = args.Value.ToString();

            if (string.IsNullOrEmpty(_tipoDeExameId))
                return;

            Guid.TryParse(_tipoDeExameId, out Guid tipoDeExameId);

            var tipoDeExame = await TiposDeExamesServico.GetAsync(tipoDeExameId);

            if (tipoDeExame == null)
                return;

            _dto.Observacao = ConstroiDocumento.ConstroiTemplate(new ExameTemplate(
                consulta.Codigo,
                consulta.Paciente.Nome,
                consulta.Paciente.DataNascimento.ToString("dd/MM/yyyy"),
                consulta.Paciente.Sexo,
                consulta.Medico.Nome,
                consulta.Medico.CRM,
                tipoDeExame.Nome));

            StateHasChanged();
        }
    }
}
