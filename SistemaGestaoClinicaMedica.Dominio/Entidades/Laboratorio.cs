using System;

namespace SistemaGestaoClinicaMedica.Dominio.Entidades
{
    public class Laboratorio : IEntidade<Guid>
    {
        public Laboratorio() { }

        public Laboratorio(Funcionario funcionario, bool daClinica)
        {
            Funcionario = funcionario;
            DaClinica = daClinica;
        }

        public Guid Id { get; set; }
        public bool DaClinica { get; set; }
        public Funcionario Funcionario { get; set; }
    }
}
