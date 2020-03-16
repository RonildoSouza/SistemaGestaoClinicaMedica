using System;

namespace SistemaGestaoClinicaMedica.Aplicacao.DTO.Login
{
    public class LoginEntradaAutenticacaoDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string CargoId { get; set; }
        public string Email { get; set; }
    }
}