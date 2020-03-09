using System;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Dominio.Entidades
{
    public class Receita : IEntidade<Guid>, IEntidadeAuditada
    {
        public Guid Id { get; set; }
        public string Observacao { get; set; }
        public List<Medicamento> Medicamentos { get; set; }
        //public Consulta Consultas { get; set; }
        public DateTime CriadoEm { get; set; }
        public string CriadoPor { get; set; }
        public DateTime? AtualizadoEm { get; set; }
        public string AtualizadoPor { get; set; }
    }
}