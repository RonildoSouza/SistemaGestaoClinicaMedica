using System;

namespace SistemaGestaoClinicaMedica.Servico.Api.DTOS
{
    public class LoginSaidaDTO
    {
        public Guid Id { get; internal set; }
        public string Nome { get; set; }
        public string CargoId { get; set; }
        public string Email { get; set; }
    }
}