using System;

namespace SistemaGestaoClinicaMedica.Dominio.Entidades
{
    public class Recepcionista : IEntidade<Guid>
    {
        public Recepcionista() { }

        public Recepcionista(Funcionario funcionario)
        {
            Funcionario = funcionario;
        }

        public Guid Id { get; set; }
        public Funcionario Funcionario { get; set; }
    }
}
