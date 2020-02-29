using System;

namespace SistemaGestaoClinicaMedica.Dominio.Entidades
{
    public class HorarioDeTrabalho : IEntidade<Guid>
    {
        public HorarioDeTrabalho() { }

        public HorarioDeTrabalho(DayOfWeek diaDaSemana, TimeSpan inicio, TimeSpan? inicioAlmoco, TimeSpan? fimAlmoco, TimeSpan fim)
        {
            DiaDaSemana = diaDaSemana;
            Inicio = inicio;
            InicioAlmoco = inicioAlmoco;
            FimAlmoco = fimAlmoco;
            Fim = fim;
        }

        public Guid Id { get; set; }
        public DayOfWeek DiaDaSemana { get; set; }
        public TimeSpan Inicio { get; set; }
        public TimeSpan? InicioAlmoco { get; set; }
        public TimeSpan? FimAlmoco { get; set; }
        public TimeSpan Fim { get; set; }
    }
}