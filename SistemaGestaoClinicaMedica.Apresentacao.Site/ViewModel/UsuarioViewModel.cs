using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.ViewModel
{
    public sealed class UsuarioViewModel
    {
        public UsuarioViewModel()
        {
            Ativo = true;
            Especialidades = new List<MedicoEspecialidadeViewModel>();
            HorariosDeTrabalho = new List<HorarioDeTrabalhoViewModel>
            {
               new HorarioDeTrabalhoViewModel(Tuple.Create((int)DayOfWeek.Monday, "Segunda-feira")),
               new HorarioDeTrabalhoViewModel(Tuple.Create((int)DayOfWeek.Tuesday, "Terça-feira" )),
               new HorarioDeTrabalhoViewModel(Tuple.Create((int)DayOfWeek.Wednesday, "Quarta-feira")),
               new HorarioDeTrabalhoViewModel(Tuple.Create((int)DayOfWeek.Thursday, "Quinta-feira")),
               new HorarioDeTrabalhoViewModel(Tuple.Create((int)DayOfWeek.Friday, "Sexta-feira")),
               new HorarioDeTrabalhoViewModel(Tuple.Create((int)DayOfWeek.Saturday, "Sábado")),
               new HorarioDeTrabalhoViewModel(Tuple.Create((int)DayOfWeek.Sunday, "Domingo"))
            };
        }

        public Guid Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Senha { get; set; }
        [Required]
        public string CargoId { get; set; }
        public bool Ativo { get; set; }
        public bool ESuperUsuario { get; set; }

        public bool DaClinica { get; set; }

        [Required]
        public string CRM { get; set; }
        public List<MedicoEspecialidadeViewModel> Especialidades { get; set; }
        public List<HorarioDeTrabalhoViewModel> HorariosDeTrabalho { get; set; }

        public static MedicoEspecialidadeViewModel ControiMedicoEspecialidade(Guid id, Guid especialidadeId, bool ativo) => new MedicoEspecialidadeViewModel
        {
            Id = id,
            EspecialidadeId = especialidadeId,
            Ativo = ativo
        };

        public sealed class MedicoEspecialidadeViewModel
        {
            public Guid Id { get; set; }
            public Guid EspecialidadeId { get; set; }
            public bool Ativo { get; set; }
        }

        public sealed class HorarioDeTrabalhoViewModel
        {
            public HorarioDeTrabalhoViewModel(Tuple<int, string> diaDaSemana)
            {
                Id = Guid.Empty;
                DiaDaSemana = diaDaSemana;
                Selecionado = false;
                Inicio =
                InicioIntervalo =
                FimIntervalo =
                Fim = new DateTime();
            }

            public Guid Id { get; set; }
            public Tuple<int, string> DiaDaSemana { get; set; }
            public DateTime Inicio { get; set; }
            public DateTime InicioIntervalo { get; set; }
            public DateTime FimIntervalo { get; set; }
            public DateTime Fim { get; set; }
            public bool Selecionado { get; set; }
        }
    }
}
