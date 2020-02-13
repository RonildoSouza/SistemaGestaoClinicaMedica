using System;

namespace SistemaGestaoClinicaMedica.Dominio.Entidades
{
    public class Atestado : IEntidade<Guid>
    {
        public Guid Id { get; set; }
        public string Observacao { get; set; }
        public TipoDeAtestado TipoDeAtestado { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}