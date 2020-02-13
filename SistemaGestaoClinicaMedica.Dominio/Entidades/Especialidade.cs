using System;

namespace SistemaGestaoClinicaMedica.Dominio.Entidades
{
    public class Especialidade : IEntidade<Guid>
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
    }
}