using Blazored.LocalStorage;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using SistemaGestaoClinicaMedica.Apresentacao.Site.Constantes;
using SistemaGestaoClinicaMedica.Apresentacao.Site.Extensions;
using SistemaGestaoClinicaMedica.Apresentacao.Site.Modelo;
using SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Pages
{
    public partial class UsuariosForm
    {
        [Parameter] public Guid Id { get; set; }

        [Inject] private IJSRuntime JSRuntime { get; set; }
        [Inject] private ILocalStorageService LocalStorage { get; set; }
        [Inject] private IToastService ToastService { get; set; }
        [Inject] private ICargosServico CargosServico { get; set; }
        [Inject] private IEspecialidadesServico EspecialidadesServico { get; set; }
        [Inject] private IAdministradoresServico AdministradoresServico { get; set; }

        private List<string> _medicamentosSelecionados = new List<string>();
        private List<CargoDTO> _cargos = new List<CargoDTO>();
        private List<EspecialidadeDTO> _especialidades = new List<EspecialidadeDTO>();
        private List<HorarioDeTrabalho> _horariosDeTrabalho = new List<HorarioDeTrabalho>();
        private UsuarioViewModel _usuarioViewModel = new UsuarioViewModel();

        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);

            var dotNetReference = DotNetObjectReference.Create(this);
            await JSRuntime.InvokeVoidAsync("select2JsInterop.startup", "#especialidades", dotNetReference, nameof(SelecionaEspecialidade));
        }

        protected async override Task OnInitializedAsync()
        {
            _cargos = await CargosServico.GetAsync();
            _especialidades = await EspecialidadesServico.GetAsync();

            _horariosDeTrabalho = new List<HorarioDeTrabalho>
            {
               new HorarioDeTrabalho(Tuple.Create((int)DayOfWeek.Monday, "Segunda-feira"), false, new DateTime(), new DateTime(), new DateTime(), new DateTime()),
               new HorarioDeTrabalho(Tuple.Create((int)DayOfWeek.Tuesday, "Terça-feira" ), false, new DateTime(), new DateTime(), new DateTime(), new DateTime()),
               new HorarioDeTrabalho(Tuple.Create((int)DayOfWeek.Wednesday, "Quarta-feira"), false, new DateTime(), new DateTime(), new DateTime(), new DateTime()),
               new HorarioDeTrabalho(Tuple.Create((int)DayOfWeek.Thursday, "Quinta-feira"), false, new DateTime(), new DateTime(), new DateTime(), new DateTime()),
               new HorarioDeTrabalho(Tuple.Create((int)DayOfWeek.Friday, "Sexta-feira"), false, new DateTime(), new DateTime(), new DateTime(), new DateTime()),
               new HorarioDeTrabalho(Tuple.Create((int)DayOfWeek.Saturday, "Sábado"), false, new DateTime(), new DateTime(), new DateTime(), new DateTime()),
               new HorarioDeTrabalho(Tuple.Create((int)DayOfWeek.Sunday, "Domingo"), false, new DateTime(), new DateTime(), new DateTime(), new DateTime()),
            };

            var cargoId = await LocalStorage.ObterUsuarioCargoIdLocalStorageAsync();
            _usuarioViewModel.CargoId = cargoId;

            switch (cargoId)
            {
                case CargosConst.Administrador:

                    var administrador = await AdministradoresServico.GetAsync(Id);
                    _usuarioViewModel.Nome = administrador.Nome;
                    _usuarioViewModel.Email = administrador.Email;
                    _usuarioViewModel.Telefone = administrador.Telefone;
                    _usuarioViewModel.Senha = administrador.Senha;

                    break;
                case CargosConst.Recepcionista:
                    break;
                case CargosConst.Laboratorio:
                    break;
                case CargosConst.Medico:
                    break;
                default:
                    break;
            }
        }

        //protected async override Task OnParametersSetAsync()
        //{

        //}

        protected async Task Salvar(EditContext editContext)
        {
            if (!editContext.Validate())
                return;

            switch (_usuarioViewModel.CargoId)
            {
                case CargosConst.Administrador:

                    var administrador = new AdministradorDTO();
                    administrador.Id = Id;
                    administrador.Nome = _usuarioViewModel.Nome;
                    administrador.Email = _usuarioViewModel.Email;
                    administrador.Telefone = _usuarioViewModel.Telefone;
                    administrador.Senha = _usuarioViewModel.Senha;

                    if (Id == Guid.Empty)
                        await AdministradoresServico.PostAsync(administrador);
                    else
                        await AdministradoresServico.PutAsync(Id, administrador);

                    break;
                case CargosConst.Recepcionista:
                    break;
                case CargosConst.Laboratorio:
                    break;
                case CargosConst.Medico:
                    break;
                default:
                    break;
            }

            //var horariosSelecionados = _horariosDeTrabalho.Where(_ => _.Selecionado);

            //if (horariosSelecionados.Any(_ => _.Fim > _.Inicio || _.FimIntervalo > _.InicioIntervalo))
            //{
            //    ToastService.ShowInfo("O horário final não pode ser maio que o horário inicial!");
            //    return;
            //}

            //if (Id == Guid.Empty)
            //{
            //    _dto.HorariosDeTrabalho = horariosSelecionados.Select(_ =>
            //        new HorarioDeTrabalhoDTO
            //        {
            //            DiaDaSemana = _.DiaDaSemana.Item1,
            //            Inicio = _.Inicio.TimeOfDay.ToString(),
            //            InicioAlmoco = _.InicioIntervalo.TimeOfDay.ToString(),
            //            FimAlmoco = _.InicioIntervalo.TimeOfDay.ToString(),
            //            Fim = _.InicioIntervalo.TimeOfDay.ToString(),
            //        }).ToList();
            //}
            //else
            //{

            //}
        }

        [JSInvokable]
        public void SelecionaEspecialidade(Select2 select2)
        {
            if (!Guid.TryParse(select2.Id, out Guid especialidadeId))
                return;

            //if (_dto.Id != Guid.Empty && _dto.MedicoEspecialidades.Any())
            //    _medicamentosSelecionados = _dto.MedicoEspecialidades.Select(_ => _.EspecialidadeId).ToList();

            //if (_dto.MedicoEspecialidades.Any(_ => _.EspecialidadeId == especialidadeId))
            //{
            //    var index = _dto.MedicoEspecialidades.FindIndex(_ => _.EspecialidadeId == especialidadeId);
            //    _dto.MedicoEspecialidades.RemoveAt(index);
            //    _medicamentosSelecionados.Remove(select2.Text);
            //}
            //else
            //{
            //    _dto.MedicoEspecialidades.Add(new FuncionarioDTO { EspecialidadeId = especialidadeId });
            //    _medicamentosSelecionados.Add(select2.Text);
            //}
        }
    }

    public class UsuarioViewModel
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Senha { get; set; }
        public string CargoId { get; set; }
    }

    public class HorarioDeTrabalho
    {
        public HorarioDeTrabalho(Tuple<int, string> diaDaSemana, bool selecionado, DateTime inicio, DateTime inicioIntervalo, DateTime fimIntervalo, DateTime fim)
        {
            DiaDaSemana = diaDaSemana;
            Selecionado = selecionado;
            Inicio = inicio;
            InicioIntervalo = inicioIntervalo;
            FimIntervalo = fimIntervalo;
            Fim = fim;
        }

        public Tuple<int, string> DiaDaSemana { get; set; }
        public bool Selecionado { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime InicioIntervalo { get; set; }
        public DateTime FimIntervalo { get; set; }
        public DateTime Fim { get; set; }
    }
}
