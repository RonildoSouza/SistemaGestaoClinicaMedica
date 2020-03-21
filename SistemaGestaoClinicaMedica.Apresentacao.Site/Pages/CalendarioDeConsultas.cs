using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using SistemaGestaoClinicaMedica.Apresentacao.Site.Extensions;
using SistemaGestaoClinicaMedica.Apresentacao.Site.Modelo;
using SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Pages
{
    public partial class CalendarioDeConsultas
    {
        private PacienteLocalStorage _pacienteLocalStorage = new PacienteLocalStorage();
        private EspecialidadeLocalStorage _especialidadeLocalStorage;
        private MedicoLocalStorage _medicoLocalStorage;

        [Inject] private IJSRuntime JSRuntime { get; set; }
        [Inject] private ILocalStorageService LocalStorage { get; set; }
        [Inject] private IConsultaServico ConsultaServico { get; set; }
        [Inject] private NavigationManager NavigationManager { get; set; }
        [Inject] private IPacienteServico PacienteServico { get; set; }
        [Inject] private IEspecialidadeServico EspecialidadeServico { get; set; }
        [Inject] private IMedicoServico MedicoServico { get; set; }

        private string PacienteCodigo { get; set; }
        private List<EspecialidadeDTO> Especialidades { get; set; }
        private List<MedicoDTO> Medicos { get; set; } = new List<MedicoDTO>();
        private bool AgendarConsulta { get; set; }

        protected async override Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            Especialidades = await EspecialidadeServico.GetDisponiveisAsync();
        }

        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);

            if (firstRender)
                await CalendarRenderAsync();
        }

        private async Task CalendarRenderAsync()
        {
            var consultas = await ConsultaServico.GetAsync();
            var fullCalendarEvent = consultas.Select(_ => new FullCalendarEvent
            {
                Id = _.Codigo,
                Title = $"Dr(a): {_.MedicoId}\nConsulta.: {_.EspecialidadeId} - Paciente: {_.PacienteId}",
                Start = _.Data
            });

            var dotNetReference = DotNetObjectReference.Create(this);

            await JSRuntime.InvokeVoidAsync(
                "fullCalendarJsInterop.calendarRender",
                fullCalendarEvent, dotNetReference);
        }

        private async Task BuscaPacienteAsync()
        {
            var paciente = await PacienteServico.GetPorCodigoAsync(PacienteCodigo);
            _pacienteLocalStorage = new PacienteLocalStorage
            {
                Id = paciente.Id,
                Nome = paciente.Nome
            };
        }

        private async Task SelecionaEspecialidadeAsync(ChangeEventArgs args)
        {
            if (string.IsNullOrEmpty(args.Value?.ToString()))
                return;

            var especialidadeId = Guid.Parse(args.Value.ToString());
            Medicos = await MedicoServico.GetPorEspecialidadeAsync(especialidadeId);

            var especialidade = Especialidades.First(_ => _.Id == especialidadeId);
            _especialidadeLocalStorage = new EspecialidadeLocalStorage
            {
                Id = especialidadeId,
                Nome = especialidade.Nome
            };
        }

        private void SelecionaMedico(ChangeEventArgs args)
        {
            if (string.IsNullOrEmpty(args.Value?.ToString()))
                return;

            var medicoId = Guid.Parse(args.Value.ToString());
            var medico = Medicos.First(_ => _.Id == medicoId);

            _medicoLocalStorage = new MedicoLocalStorage
            {
                Id = medicoId,
                Nome = medico.Nome,
                CRM = medico.CRM
            };
        }

        [JSInvokable]
        public async Task AgendarConsultaAsync(DateTime data)
        {
            if (_pacienteLocalStorage == default && _especialidadeLocalStorage == default && _medicoLocalStorage == default)
                return;

            await LocalStorage.CriaConsultaLocalStorageAsync(new ConsultaLocalStorage
            {
                Data = data,
                Paciente = _pacienteLocalStorage,
                Especialidade = _especialidadeLocalStorage,
                Medico = _medicoLocalStorage,
            });

            NavigationManager.NavigateTo($"consultas/novo");
        }
    }
}
