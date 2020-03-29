using System;

namespace SistemaGestaoClinicaMedica.Dominio.Entidades
{
    public class HorarioDeTrabalho : IEntidade<Guid>
    {
        public Guid Id { get; set; }
        public DayOfWeek DiaDaSemana { get; set; }
        public TimeSpan Inicio { get; set; }
        public TimeSpan InicioIntervalo { get; set; }
        public TimeSpan FimIntervalo { get; set; }
        public TimeSpan Fim { get; set; }
        public bool Ativo { get; set; }
    }
}