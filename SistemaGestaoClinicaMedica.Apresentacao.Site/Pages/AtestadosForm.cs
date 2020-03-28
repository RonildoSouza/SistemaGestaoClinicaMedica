using Microsoft.AspNetCore.Components;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Pages
{
    public partial class AtestadosForm
    {
        [Parameter] public Guid ConsultaId { get; set; }

        [Inject] private ITiposDeAtestadosServico TiposDeAtestadoServico { get; set; }

        private List<TipoDeAtestadoDTO> TiposDeAtestados { get; set; } = new List<TipoDeAtestadoDTO>();

        protected async override Task OnInitializedAsync()
        {
            TiposDeAtestados = await TiposDeAtestadoServico.GetAsync();
        }

        protected async override Task OnParametersSetAsync()
        {
            await base.OnParametersSetAsync();

            if (_dto.ConsultaId == Guid.Empty)
                _dto.ConsultaId = ConsultaId;
        }
    }
}
