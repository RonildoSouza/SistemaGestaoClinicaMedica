using System;
using System.ComponentModel.DataAnnotations;

namespace SistemaGestaoClinicaMedica.Aplicacao.DTO
{
    public class MedicamentoDTO : IDTO<Guid>
    {
        public Guid Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string NomeFabrica { get; set; }
        [Required]
        public string Tarja { get; set; }
        [Required]
        public string FabricanteNome { get; set; }
        public bool Ativo { get; set; } = true;
    }
}
