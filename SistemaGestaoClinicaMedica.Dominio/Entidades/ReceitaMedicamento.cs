using System;

namespace SistemaGestaoClinicaMedica.Dominio.Entidades
{
    public class ReceitaMedicamento : IEntidade<Guid>
    {
        public Guid Id { get; set; }

        public Guid ReceitaId { get; set; }
        public Receita Receita { get; set; }

        public Guid MedicamentoId { get; set; }
        public Medicamento Medicamento { get; set; }

        public bool Ativo { get; set; }
    }
}
