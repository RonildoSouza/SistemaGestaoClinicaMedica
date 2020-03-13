using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Medicamento;
using System;

namespace SistemaGestaoClinicaMedica.Aplicacao.DTOS.Receita
{
    public class ReceitaMedicamentoSaidaDTO
    {
        public Guid Id { get; set; }
        public MedicamentoSaidaDTO Medicamento { get; set; }
    }
}
