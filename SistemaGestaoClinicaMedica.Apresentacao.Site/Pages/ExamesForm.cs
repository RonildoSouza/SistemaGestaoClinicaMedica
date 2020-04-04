using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using SistemaGestaoClinicaMedica.Apresentacao.Site.Constantes;
using SistemaGestaoClinicaMedica.Apresentacao.Site.Extensions;
using SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Pages
{
    public partial class ExamesForm
    {
        private List<TipoDeExameDTO> _tiposDeExames = new List<TipoDeExameDTO>();
        private string _tipoDeExameId;

        [Parameter] public Guid ConsultaId { get; set; }

        [Inject] private IJSRuntime JSRuntime { get; set; }
        [Inject] private ITiposDeExamesServico TiposDeExamesServico { get; set; }
        [Inject] private IConsultasServico ConsultasServico { get; set; }

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
    }
}
