using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using SistemaGestaoClinicaMedica.Apresentacao.Site.Extensions;
using SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Pages
{
    public partial class AtestadosForm
    {
        private List<TipoDeAtestadoDTO> _tiposDeAtestados = new List<TipoDeAtestadoDTO>();

        [Parameter] public Guid ConsultaId { get; set; }

        [Inject] private IJSRuntime JSRuntime { get; set; }
        [Inject] private ITiposDeAtestadosServico TiposDeAtestadoServico { get; set; }

        protected async override Task OnInitializedAsync()
        {
            _tiposDeAtestados = await TiposDeAtestadoServico.GetAsync();
        }

        protected async override Task OnParametersSetAsync()
        {
            await base.OnParametersSetAsync();

            if (_dto.ConsultaId == Guid.Empty)
                _dto.ConsultaId = ConsultaId;
        }

        protected async override Task<bool> Salvar(EditContext editContext)
        {
            var result = await base.Salvar(editContext);
            if (result)
                await JSRuntime.PrintContentAsync("atestado-observacao");

            return result;
        }
    }
}
