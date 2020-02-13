using System;

namespace SistemaGestaoClinicaMedica.Dominio.Entidades
{
    public class Exame
    {
        public Guid Id { get; set; }
        public TipoDeExame TipoDeExame { get; set; }
        public string Observacao { get; set; }
        public StatusExame StatusExame { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}