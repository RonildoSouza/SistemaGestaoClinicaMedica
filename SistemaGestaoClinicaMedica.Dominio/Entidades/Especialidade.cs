using System;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Dominio.Entidades
{
    public class Especialidade : IEntidade<Guid>
    {
        public Especialidade() { }

        public Especialidade(string nome)
        {
            Id = Guid.NewGuid();
            Nome = nome;
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }

        public List<MedicoEspecialidade> Medicos { get; set; }
    }
}