using System;

namespace SistemaGestaoClinicaMedica.Dominio.Entidades
{
    public class TipoDeExame : IEntidade<Guid>
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
    }
}