using System;

namespace SistemaGestaoClinicaMedica.Dominio.Entidades
{
    public class Administrador : IEntidade<Guid>
    {
        public Administrador() { }

        public Administrador(Funcionario funcionario)
        {
            //Id = Guid.NewGuid();
            Funcionario = funcionario;
        }

        public Guid Id { get; set; }
        //public Guid FuncionarioId { get; set; }
        public Funcionario Funcionario { get; set; }
    }
}
