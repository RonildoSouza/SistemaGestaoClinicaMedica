using System;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Dominio.Entidades
{
    public class Receita : IEntidade<Guid>, IEntidadeAuditada
    {
        public Receita() { }

        public Receita(Guid id, string observacao, List<ReceitaMedicamento> medicamentos, Consulta consulta)
        {
            Id = id;
            Observacao = observacao;
            Medicamentos = medicamentos;
            Consulta = consulta;
        }

        public Guid Id { get; set; }
        public string Observacao { get; set; }
        public List<ReceitaMedicamento> Medicamentos { get; set; }
        public Consulta Consulta { get; set; }
        public DateTime CriadoEm { get; set; }
        public string CriadoPor { get; set; }
        public DateTime? AtualizadoEm { get; set; }
        public string AtualizadoPor { get; set; }
    }
}