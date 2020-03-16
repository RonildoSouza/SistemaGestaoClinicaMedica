using System;
using System.ComponentModel.DataAnnotations;

namespace SistemaGestaoClinicaMedica.Aplicacao.DTO
{
    public class FabricanteDTO
    {
        public Guid Id { get; set; }
        [Required]
        public string Nome { get; set; }
    }
}
