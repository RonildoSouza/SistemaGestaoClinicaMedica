using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Pages
{
    public partial class ExamesForm
    {
        [Parameter] public Guid ConsultaId { get; set; }

        [Inject] public ITipoDeExameServico TipoDeExameServico { get; set; }

        public List<TipoDeExameDTO> TiposDeExames { get; set; } = new List<TipoDeExameDTO>();
        public string TipoDeExameId { get; set; }

        protected async override Task OnInitializedAsync()
        {
            TiposDeExames = await TipoDeExameServico.GetAsync();
        }

        protected async override Task OnParametersSetAsync()
        {
            await base.OnParametersSetAsync();

            if (_dto.ConsultaId == Guid.Empty)
                _dto.ConsultaId = ConsultaId;

            if (_dto?.Id != Guid.Empty)
                TipoDeExameId = _dto.TipoDeExame.Id.ToString();
        }

        protected async override Task Salvar(EditContext editContext)
        {
            if (string.IsNullOrEmpty(TipoDeExameId))
                return;

            _dto.StatusExame.Id = "Pendente";
            _dto.TipoDeExame.Id = Guid.Parse(TipoDeExameId);
            await base.Salvar(editContext);
        }
    }
}
