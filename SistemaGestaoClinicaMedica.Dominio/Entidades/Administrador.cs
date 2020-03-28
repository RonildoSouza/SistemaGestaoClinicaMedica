using System;

namespace SistemaGestaoClinicaMedica.Dominio.Entidades
{
    public class Administrador : IEntidade<Guid>
    {
        public Administrador() { }

        public Administrador(Usuario usuario)
        {
            Usuario = usuario;
        }

        public Guid Id { get; set; }
        public Usuario Usuario { get; set; }
    }
}
