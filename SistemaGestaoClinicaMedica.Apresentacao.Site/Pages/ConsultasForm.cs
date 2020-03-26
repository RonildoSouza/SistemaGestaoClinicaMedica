﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using SistemaGestaoClinicaMedica.Apresentacao.Site.Extensions;
using SistemaGestaoClinicaMedica.Apresentacao.Site.Modelo;
using SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Pages
{
    public partial class ConsultasForm
    {
        [Inject] public IStatusConsultaServico StatusConsultaServico { get; set; }
        [Inject] private IJSRuntime JSRuntime { get; set; }

        public List<StatusConsultaDTO> StatusConsulta { get; set; } = new List<StatusConsultaDTO>();

        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            await JSRuntime.ShowTabFromUrlId();
        }

        protected async override Task OnParametersSetAsync()
        {
            await base.OnParametersSetAsync();
            StatusConsulta = await StatusConsultaServico.GetAsync();
        }

        protected override Task Salvar(EditContext editContext)
        {
            if (_dto.StatusConsultaId == StatusConsultaConst.Agendada)
                _dto.StatusConsultaId = StatusConsultaConst.Concluida;

            return base.Salvar(editContext);
        }
    }
}
