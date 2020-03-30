using System;

namespace SistemaGestaoClinicaMedica.Aplicacao.DTO
{
    public class ReceitaMedicamentoDTO
    {
        public Guid Id { get; set; }
        public Guid MedicamentoId { get; set; }
        public MedicamentoDTO Medicamento { get; set; }
        public bool Ativo { get; set; }
    }
}
