using System;

namespace SistemaGestaoClinicaMedica.Dominio.Entidades
{
    public class Fabricante : IEntidade<Guid>
    {
        public Fabricante() { }

        public Fabricante(Guid id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
    }
}