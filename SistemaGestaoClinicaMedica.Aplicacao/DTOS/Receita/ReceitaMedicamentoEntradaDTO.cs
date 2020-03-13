using System;

namespace SistemaGestaoClinicaMedica.Aplicacao.DTOS.Receita
{
    public class ReceitaMedicamentoEntradaDTO
    {
        public Guid Id { get; set; }
        public Guid MedicamentoId { get; set; }
    }
}
