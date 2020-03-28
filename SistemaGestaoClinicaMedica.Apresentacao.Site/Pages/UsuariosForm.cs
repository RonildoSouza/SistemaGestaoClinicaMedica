using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using SistemaGestaoClinicaMedica.Apresentacao.Site.Modelo;
using SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Pages
{
    public partial class UsuariosForm
    {
        private List<string> _medicamentosSelecionados = new List<string>();
        private object _dto;

        [Inject] private IJSRuntime JSRuntime { get; set; }
        [Inject] private ICargosServico CargosServico { get; set; }
        [Inject] private IEspecialidadesServico EspecialidadesServico { get; set; }

        private List<CargoDTO> Cargos { get; set; } = new List<CargoDTO>();
        private List<EspecialidadeDTO> Especialidades { get; set; } = new List<EspecialidadeDTO>();
        private Dictionary<int, string> DiasDaSemana => new Dictionary<int, string>
            {
                {(int)DayOfWeek.Monday, "Segunda-feira" },
                {(int)DayOfWeek.Tuesday, "Terça-feira" },
                {(int)DayOfWeek.Wednesday, "Quarta-feira" },
                {(int)DayOfWeek.Thursday, "Quinta-feira" },
                {(int)DayOfWeek.Friday, "Sexta-feira" },
                {(int)DayOfWeek.Saturday, "Sábado" },
                {(int)DayOfWeek.Sunday, "Domingo" },
            };

        private List<HorarioDeTrabalho> HorariosDeTrabalho { get; set; } = new List<HorarioDeTrabalho>();

        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);

            var dotNetReference = DotNetObjectReference.Create(this);
            await JSRuntime.InvokeVoidAsync("select2JsInterop.startup", "#especialidades", dotNetReference, nameof(SelecionaEspecialidade));
        }

        protected async override Task OnInitializedAsync()
        {
            Cargos = await CargosServico.GetAsync();
            Especialidades = await EspecialidadesServico.GetAsync();

            HorariosDeTrabalho = new List<HorarioDeTrabalho>
            {
               new HorarioDeTrabalho(Tuple.Create((int)DayOfWeek.Monday, "Segunda-feira"), false, new DateTime(), new DateTime(), new DateTime(), new DateTime()),
               new HorarioDeTrabalho(Tuple.Create((int)DayOfWeek.Tuesday, "Terça-feira" ), false, new DateTime(), new DateTime(), new DateTime(), new DateTime()),
               new HorarioDeTrabalho(Tuple.Create((int)DayOfWeek.Wednesday, "Quarta-feira"), false, new DateTime(), new DateTime(), new DateTime(), new DateTime()),
               new HorarioDeTrabalho(Tuple.Create((int)DayOfWeek.Thursday, "Quinta-feira"), false, new DateTime(), new DateTime(), new DateTime(), new DateTime()),
               new HorarioDeTrabalho(Tuple.Create((int)DayOfWeek.Friday, "Sexta-feira"), false, new DateTime(), new DateTime(), new DateTime(), new DateTime()),
               new HorarioDeTrabalho(Tuple.Create((int)DayOfWeek.Saturday, "Sábado"), false, new DateTime(), new DateTime(), new DateTime(), new DateTime()),
               new HorarioDeTrabalho(Tuple.Create((int)DayOfWeek.Sunday, "Domingo"), false, new DateTime(), new DateTime(), new DateTime(), new DateTime()),
            };
        }

        //private void SelecionaDiaDaSemana(int dia)
        //{

        //}

        protected async Task Salvar(EditContext editContext)
        {
            if (!editContext.Validate())
                return;

            var horariosSelecionados = HorariosDeTrabalho.Where(_ => _.Selecionado);

            if (horariosSelecionados.Any(_ => _.Fim > _.Inicio || _.FimIntervalo > _.InicioIntervalo))
            {
                //ToastService.ShowInfo("O horário final não pode ser maio que o horário inicial!");
                return;
            }

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
