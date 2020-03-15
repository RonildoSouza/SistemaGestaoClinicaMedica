using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using SistemaGestaoClinicaMedica.Apresentacao.Site.Modelo;
using SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Pages
{
    public partial class CalendarioDeContatos
    {
        [Inject]
        private IJSRuntime JSRuntime { get; set; }

        [Inject]
        private IConsultaServico ConsultaServico { get; set; }

        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            await CalendarRender();
        }

        public async Task CalendarRender()
        {
            var consultas = await ConsultaServico.GetAsync();
            var fullCalendarEvent = consultas.Select(_ => new FullCalendarEvent
            {
                Id = _.Codigo,
                Title = $"Dr(a): {_.Medico.Nome}\nConsulta.: {_.Especialidade} - Paciente: {_.Paciente.Nome}",
                Start = _.Data
            });

            await JSRuntime.InvokeVoidAsync(
                "fullCalendarJsInterop.calendarRender",
                fullCalendarEvent);
        }
    }
}
