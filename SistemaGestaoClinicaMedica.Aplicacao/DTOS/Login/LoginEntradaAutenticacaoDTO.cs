using System;

namespace SistemaGestaoClinicaMedica.Servico.Api.DTOS
{
    public class LoginEntradaAutenticacaoDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string CargoId { get; set; }
        public string Email { get; set; }
    }
}