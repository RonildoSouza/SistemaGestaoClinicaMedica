using System;
using System.ComponentModel.DataAnnotations;

namespace SistemaGestaoClinicaMedica.Aplicacao.DTO.Login
{
    public class LoginEntradaAutenticacaoDTO
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string CargoId { get; set; }
        [Required]
        public string Email { get; set; }
    }
}