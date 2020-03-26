using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using SistemaGestaoClinicaMedica.Apresentacao.Site.Extensions;
using SistemaGestaoClinicaMedica.Apresentacao.Site.Modelo;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Pages
{
    public partial class ConsultasForm
    {
        [Inject] private IJSRuntime JSRuntime { get; set; }

        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            await JSRuntime.ShowTabFromUrlId();
        }

        protected override Task Salvar(EditContext editContext)
        {
            if (_dto.StatusConsultaId == StatusConsultaConst.Agendada)
                _dto.StatusConsultaId = StatusConsultaConst.Concluida;

            return base.Salvar(editContext);
        }
    }
}
