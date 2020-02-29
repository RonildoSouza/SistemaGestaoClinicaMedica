using System;

namespace SistemaGestaoClinicaMedica.Dominio.Entidades
{
    public class Laboratorio : IEntidade<Guid>
    {
        public Laboratorio() { }

        public Laboratorio(Funcionario funcionario)
        {
            Funcionario = funcionario;
        }

        public Guid Id { get; set; }
        public Funcionario Funcionario { get; set; }
    }
}
