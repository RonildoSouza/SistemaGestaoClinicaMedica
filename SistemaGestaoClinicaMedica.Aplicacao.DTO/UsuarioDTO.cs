using System;

namespace SistemaGestaoClinicaMedica.Aplicacao.DTO
{
    public class UsuarioDTO : IDTO<Guid>
    {
        public UsuarioDTO()
        {
            Cargo = new CargoDTO();
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Senha { get; set; }
        public CargoDTO Cargo { get; set; }
        public bool Ativo { get; set; }

        public bool ESuperUsuario { get; set; }
    }
}
