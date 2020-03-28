using System;

namespace SistemaGestaoClinicaMedica.Dominio.Entidades
{
    public class Recepcionista : IEntidade<Guid>
    {
        public Recepcionista() { }

        public Recepcionista(Usuario usuario)
        {
            Usuario = usuario;
        }

        public Guid Id { get; set; }
        public Usuario Usuario { get; set; }
    }
}
