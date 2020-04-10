using Blazored.LocalStorage;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using SistemaGestaoClinicaMedica.Apresentacao.Site.Constantes;
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
        private static DateTime _fullCalendarCurrentStartDate;
        private string _pacienteCodigoOuCPF;
        private List<EspecialidadeDTO> _especialidades;
        private List<MedicoDTO> _medicos = new List<MedicoDTO>();
        private bool _agendarConsulta;
        private List<TimeSpan> _horariosDisponiveis = new List<TimeSpan>();
        private DateTime _dataDaConsulta;
        private TimeSpan _horarioDaConsulta;
        private ConsultaEvento _consultaEvento = new ConsultaEvento();
        private bool _carregando;
        private string _busca;
        private bool _alterouDataReagendamento;

        [Inject] private IJSRuntime JSRuntime { get; set; }
        [Inject] private ILocalStorageService LocalStorage { get; set; }
        [Inject] private IToastService ToastService { get; set; }
        [Inject] private IConsultasServico ConsultasServico { get; set; }
        [Inject] private NavigationManager NavigationManager { get; set; }
        [Inject] private IPacientesServico PacientesServico { get; set; }
        [Inject] private IEspecialidadesServico EspecialidadesServico { get; set; }
        [Inject] private IMedicosServico MedicosServico { get; set; }

        protected async override Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            _especialidades = await EspecialidadesServico.GetDisponiveisAsync();
        }

        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);

            if (firstRender)
                await CalendarRenderAsync(DateTime.Today, DateTime.Today.AddYears(1));
        }

        private async Task CalendarRenderAsync(DateTime dataInicio, DateTime dataFim, string busca = "", string viewRender = null, DateTime? gotoDate = null)
        {
            _carregando = true;
            StateHasChanged();

            var consultas = await ConsultasServico.GetTudoComFiltrosAsync(dataInicio, dataFim, busca, "Agendada|AguardandoRetorno|Reagendada");
            var datas = await EspecialidadesServico.GetObterDatasComHorariosDisponiveisAsync((_especialidadeLocalStorage?.Id).GetValueOrDefault(), dataInicio, dataFim, _medicoLocalStorage?.Id);

            var fullCalendarEvent = consultas.Select(_ => new FullCalendarEvent
            {
                Id = _.Id.ToString(),
                Title = $"Código: {_.Codigo} - {_.Especialidade.Nome}\nPaciente: {_.Paciente.Nome}",
                Start = _.Data,
                ExtendedProps = new
                {
                    ConsultaCodigo = _.Codigo,
                    PacienteNome = _.Paciente.Nome,
                    EspecialidadeId = _.Especialidade.Id,
                    EspecialidadeNome = _.Especialidade.Nome,
                    MedicoId = _.Medico.Id,
                    MedicoNome = $"{_.Medico.Nome} - CRM {_.Medico.CRM}",
                    StatusId = _.StatusConsulta.Id,
                    StatusNome = _.StatusConsulta.Nome,
                },
                BackgroundColor = ObterEventoCor(_.StatusConsultaId).Item1,
                TextColor = ObterEventoCor(_.StatusConsultaId).Item2,
            });

            _carregando = false;
            StateHasChanged();

            var dotNetReference = DotNetObjectReference.Create(this);

            await JSRuntime.InvokeVoidAsync(
                "fullCalendarJsInterop.calendarRender",
                fullCalendarEvent,
                dotNetReference,
                datas?.Select(_ => new { Data = _.Key, TemHorario = _.Value }),
                viewRender,
                gotoDate);
        }

        private async Task BuscaPacienteAsync()
        {
            if (string.IsNullOrEmpty(_pacienteCodigoOuCPF) || _pacienteCodigoOuCPF.Length < 4)
            {
                ToastService.ShowInfo($"O código ou CPF {_pacienteCodigoOuCPF} do paciente é inválido!");
                return;
            }

            var paciente = await PacientesServico.GetPorCodigoOuCPFAsync(_pacienteCodigoOuCPF);
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
            _medicos = await MedicosServico.GetPorEspecialidadeAsync(especialidadeId);

            var especialidade = _especialidades.First(_ => _.Id == especialidadeId);
            _especialidadeLocalStorage = new EspecialidadeLocalStorage
            {
                Id = especialidadeId,
                Nome = especialidade.Nome
            };

            await CalendarReRenderAsync();
        }

        private async Task SelecionaMedico(ChangeEventArgs args)
        {
            if (string.IsNullOrEmpty(args.Value?.ToString()))
                return;

            var medicoId = Guid.Parse(args.Value.ToString());
            var medico = _medicos.First(_ => _.Id == medicoId);

            _medicoLocalStorage = new MedicoLocalStorage
            {
                Id = medicoId,
                Nome = medico.Nome,
                CRM = medico.CRM
            };

            if (_medicos.Count > 1)
                await CalendarReRenderAsync();
        }

        private async Task AgendarConsultaAsync()
        {
            if (_medicoLocalStorage == null)
            {
                ToastService.ShowInfo("Falta informar o Médico!");
                await JSRuntime.ScrollToAsync();
                return;
            }

            await LocalStorage.CriaConsultaLocalStorageAsync(new ConsultaLocalStorage
            {
                Data = _dataDaConsulta.Add(_horarioDaConsulta),
                Paciente = _pacienteLocalStorage,
                Especialidade = _especialidadeLocalStorage,
                Medico = _medicoLocalStorage,
            });

            NavigationManager.NavigateTo($"consultas/novo");
        }

        private async Task DesmarcarConsultaAsync()
        {
            if (!Guid.TryParse(_consultaEvento.Id, out Guid consultaId))
                return;

            var httpResponse = await ConsultasServico.DeleteAsync(consultaId);

            if (httpResponse.IsSuccessStatusCode)
            {
                ToastService.ShowSuccess($"Consulta de código {_consultaEvento.Codigo}, foi desmarcada!");
                await CalendarRenderAsync(DateTime.Today, DateTime.Today.AddYears(1));
            }
        }

        private async Task ReAgendarConsultaAsync()
        {
            if (!Guid.TryParse(_consultaEvento.Id, out Guid consultaId))
                return;

            if (_dataDaConsulta == DateTime.MinValue || _dataDaConsulta < DateTime.Now)
            {
                ToastService.ShowError("A data selecionada é inválido!");
                return;
            }

            var consulta = await ConsultasServico.GetAsync(consultaId);
            var dto = new ConsultaDTO
            {
                Data = _dataDaConsulta.Add(_horarioDaConsulta),
                Observacao = consulta.Observacao,
                StatusConsultaId = StatusConsultaConst.Reagendada,
                PacienteId = consulta.PacienteId,
                MedicoId = consulta.MedicoId,
                EspecialidadeId = consulta.EspecialidadeId,
            };

            var httpResponse = await ConsultasServico.PutAsync(consultaId, dto);

            if (httpResponse.IsSuccessStatusCode)
            {
                ToastService.ShowSuccess($"Consulta de código {_consultaEvento.Codigo}, foi reagendada!");
                await CalendarRenderAsync(DateTime.Today, DateTime.Today.AddYears(1));
            }
            else
            {
                ToastService.ShowError($"Falha ao tentar reagendar a consulta de código {_consultaEvento.Codigo}!");
            }
        }

        private void Cancelar()
        {
            _agendarConsulta = !_agendarConsulta;
            _pacienteCodigoOuCPF = string.Empty;
            _pacienteLocalStorage = new PacienteLocalStorage();

            StateHasChanged();
        }

        private async Task CalendarReRenderAsync()
        {
            var dataInicio = _fullCalendarCurrentStartDate;
            var dataFim = _fullCalendarCurrentStartDate.AddMonths(2);

            await CalendarRenderAsync(dataInicio, dataFim, gotoDate: dataInicio);
        }

        private async Task AlteraDataReagendamento(ChangeEventArgs args)
        {
            if (!DateTime.TryParse(args.Value.ToString(), out DateTime data))
                return;

            if (data < DateTime.Now)
            {
                ToastService.ShowError("A data selecionada é menor que a atual!");
                return;
            }

            var especialidadeId = Guid.Parse(_consultaEvento.EspecialidadeId);
            var medicoId = Guid.Parse(_consultaEvento.MedicoId);

            _alterouDataReagendamento = true;
            _dataDaConsulta = data;
            _horariosDisponiveis = await EspecialidadesServico.GetHorariosDisponiveisAsync(especialidadeId, _dataDaConsulta, medicoId);
            StateHasChanged();
        }

        private void SelecionaHorarioReagendamento(ChangeEventArgs args)
        {
            if (!TimeSpan.TryParse(args.Value.ToString(), out TimeSpan horarioDaConsulta))
            {
                ToastService.ShowError("O horário selecionado é inválido");
                return;
            }

            _horarioDaConsulta = horarioDaConsulta;
        }

        private async Task BuscarAsync()
        {
            if (string.IsNullOrEmpty(_busca))
                return;

            var consulta = await ConsultasServico.GetPorCodigoAsync(_busca);

            if (consulta == null)
            {
                ToastService.ShowInfo($"Nenhuma consulta encontrada com o código {_busca}");
                return;
            }

            await CalendarRenderAsync(consulta.Data, consulta.Data, _busca, "listWeek", consulta.Data);
        }

        private Tuple<string, string> ObterEventoCor(string statusConsultaId)
        {
            if (statusConsultaId == StatusConsultaConst.AguardandoRetorno)
                return Tuple.Create("#6c757d", "#fff");

            if (statusConsultaId == StatusConsultaConst.Agendada)
                return Tuple.Create("#ffc107", "#212529");

            return Tuple.Create("#BF360C", "#fff");
        }

        [JSInvokable]
        public void SetCurrentStartDate(DateTime dateTime) => _fullCalendarCurrentStartDate = dateTime;

        [JSInvokable]
        public async Task HorariosDisponiveisAsync(DateTime dataDaConsulta)
        {
            if (!_agendarConsulta)
                return;

            if (_pacienteLocalStorage.Id == Guid.Empty || _especialidadeLocalStorage == null)
            {
                ToastService.ShowInfo("Falta informar o Paciente e/ou Especialidade");
                await JSRuntime.ScrollToAsync();
                return;
            }

            _dataDaConsulta = dataDaConsulta.AddHours(-dataDaConsulta.Hour);

            _horariosDisponiveis = await EspecialidadesServico.GetHorariosDisponiveisAsync(_especialidadeLocalStorage.Id, _dataDaConsulta, _medicoLocalStorage?.Id);
            StateHasChanged();

            await JSRuntime.InvokeVoidAsync("calendarioDeConsultasJsInterop.showModalHorarioConsulta");
        }

        [JSInvokable]
        public async Task DetalhesConsultaAsync(ConsultaEvento consultaEvento)
        {
            _consultaEvento = consultaEvento;
            StateHasChanged();
            await JSRuntime.InvokeVoidAsync("calendarioDeConsultasJsInterop.showModalDesmarcarConsulta");
        }
    }
}
