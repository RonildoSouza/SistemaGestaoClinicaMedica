using Blazored.LocalStorage;
using Blazored.Toast.Services;
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
        [Inject] private IToastService ToastService { get; set; }
        [Inject] private IConsultaServico ConsultaServico { get; set; }
        [Inject] private NavigationManager NavigationManager { get; set; }
        [Inject] private IPacienteServico PacienteServico { get; set; }
        [Inject] private IEspecialidadeServico EspecialidadeServico { get; set; }
        [Inject] private IMedicoServico MedicoServico { get; set; }

        private string PacienteCodigo { get; set; }
        private List<EspecialidadeDTO> Especialidades { get; set; }
        private List<MedicoDTO> Medicos { get; set; } = new List<MedicoDTO>();
        private bool AgendarConsulta { get; set; }
        private List<TimeSpan> HorariosDisponiveis { get; set; } = new List<TimeSpan>();
        private DateTime DataDaConsulta { get; set; }
        private TimeSpan HorarioDaConsulta { get; set; }
        private ConsultaEvento ConsultaEvento { get; set; } = new ConsultaEvento();

        protected async override Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            Especialidades = await EspecialidadeServico.GetDisponiveisAsync();
        }

        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);

            if (firstRender)
                await CalendarRenderAsync(DateTime.Today, DateTime.Today.AddYears(1));
        }

        private async Task CalendarRenderAsync(DateTime dataInicio, DateTime dataFim, string busca = "", string status = "Agendada|AguardandoRetorno")
        {
            var consultas = await ConsultaServico.GetTudoComFiltrosAsync(dataInicio, dataFim, busca, status);


            var fullCalendarEvent = consultas.Select(_ => new FullCalendarEvent
            {
                Id = _.Id.ToString(),
                Title = $"Código: {_.Codigo} - {_.Especialidade.Nome}\nPaciente: {_.Paciente.Nome}",
                Start = _.Data,
                ExtendedProps = new
                {
                    ConsultaCodigo = _.Codigo,
                    PacienteNome = _.Paciente.Nome,
                    EspecialidadeNome = _.Especialidade.Nome,
                    MedicoNome = $"{_.Medico.Nome} - CRM {_.Medico.CRM}",
                    StatusId = _.StatusConsulta.Id
                }
            });

            var dotNetReference = DotNetObjectReference.Create(this);

            await JSRuntime.InvokeVoidAsync(
                "fullCalendarJsInterop.calendarRender",
                fullCalendarEvent, dotNetReference);
        }

        private async Task BuscaPacienteAsync()
        {
            var paciente = await PacienteServico.GetPorCodigoAsync(PacienteCodigo);
            if (paciente == null)
            {
                ToastService.ShowInfo("Nenhum paciente encontrado!");
                return;
            }

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

        public async Task AgendarConsultaAsync()
        {
            if (_medicoLocalStorage == null)
            {
                ToastService.ShowInfo("Falta informar Médico!");
                await JSRuntime.ScrollTo();
                return;
            }

            await LocalStorage.CriaConsultaLocalStorageAsync(new ConsultaLocalStorage
            {
                Data = DataDaConsulta.Add(HorarioDaConsulta),
                Paciente = _pacienteLocalStorage,
                Especialidade = _especialidadeLocalStorage,
                Medico = _medicoLocalStorage,
            });

            NavigationManager.NavigateTo($"consultas/novo");
        }

        public async Task DesmarcarConsultaAsync()
        {
            if (!Guid.TryParse(ConsultaEvento.Id, out Guid consultaId))
                return;

            var httpResponse = await ConsultaServico.DeleteAsync(consultaId);

            if (httpResponse.IsSuccessStatusCode)
            {
                ToastService.ShowSuccess($"Consulta de código {ConsultaEvento.Codigo}, foi desmarcada!");
                await CalendarRenderAsync(DateTime.Today, DateTime.Today.AddYears(1));
            }
        }

        [JSInvokable]
        public async Task HorariosDisponiveisAsync(DateTime dataDaConsulta)
        {
            if (!AgendarConsulta)
                return;

            if (_pacienteLocalStorage.Id == Guid.Empty || _especialidadeLocalStorage == null)
            {
                ToastService.ShowInfo("Falta informar o Paciente e/ou Especialidade");
                await JSRuntime.ScrollTo();
                return;
            }

            DataDaConsulta = dataDaConsulta.AddHours(-dataDaConsulta.Hour);

            HorariosDisponiveis = await EspecialidadeServico.GetHorariosDisponiveisAsync(_especialidadeLocalStorage.Id, DataDaConsulta, _medicoLocalStorage?.Id);
            StateHasChanged();

            await JSRuntime.InvokeVoidAsync("calendarioDeConsultasJsInterop.showModalHorarioConsulta");
        }

        [JSInvokable]
        public async Task DetalhesConsultaAsync(ConsultaEvento consultaEvento)
        {
            ConsultaEvento = consultaEvento;
            StateHasChanged();
            await JSRuntime.InvokeVoidAsync("calendarioDeConsultasJsInterop.showModalDesmarcarConsulta");
        }
    }
}
