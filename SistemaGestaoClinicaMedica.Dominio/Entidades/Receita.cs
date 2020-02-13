using System;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Dominio.Entidades
{
    public class Receita : IEntidade<Guid>
    {
        public Guid Id { get; set; }
        public string Observacao { get; set; }
        public DateTime CriadoEm { get; set; }
        public List<Medicamento> Medicamentos { get; set; }
    }
}