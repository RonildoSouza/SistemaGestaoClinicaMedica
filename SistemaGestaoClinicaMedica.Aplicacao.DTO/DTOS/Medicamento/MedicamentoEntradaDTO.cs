using System;
using System.ComponentModel.DataAnnotations;

namespace SistemaGestaoClinicaMedica.Aplicacao.DTOS.Medicamento
{
    public class MedicamentoEntradaDTO : IEntradaDTO<Guid>
    {
        public Guid Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string NomeFabrica { get; set; }
        [Required]
        public string Tarja { get; set; }
        //[Required]
        public Guid FabricanteId { get; set; }
        [Required]
        public string FabricanteNome { get; set; }
        public bool Ativo { get; set; } = true;
    }
}
