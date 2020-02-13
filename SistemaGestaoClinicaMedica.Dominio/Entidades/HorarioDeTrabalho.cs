using System;

namespace SistemaGestaoClinicaMedica.Dominio.Entidades
{
    public class HorarioDeTrabalho : IEntidade<Guid>
    {
        public Guid Id { get; set; }
        public DayOfWeek DiaDaSemana { get; set; }
        public TimeSpan Inicio { get; set; }
        public TimeSpan? InicioAlmoco { get; set; }
        public TimeSpan? FimAlmoco { get; set; }
        public TimeSpan Fim { get; set; }
    }
}