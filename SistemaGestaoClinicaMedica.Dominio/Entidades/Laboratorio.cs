using System;

namespace SistemaGestaoClinicaMedica.Dominio.Entidades
{
    public class Laboratorio : IEntidade<Guid>
    {
        public Laboratorio() { }

        public Laboratorio(Usuario usuario, bool daClinica)
        {
            Usuario = usuario;
            DaClinica = daClinica;
        }

        public Guid Id { get; set; }
        public bool DaClinica { get; set; }
        public Usuario Usuario { get; set; }
    }
}
