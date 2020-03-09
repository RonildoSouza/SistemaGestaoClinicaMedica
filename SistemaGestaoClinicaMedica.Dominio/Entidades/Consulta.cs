using System;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Dominio.Entidades
{
    public class Consulta : IEntidade<Guid>, IEntidadeAuditada
    {
        public Consulta() { }

        public Consulta(Guid id, DateTime data, string observacao, StatusConsulta statusConsulta, Paciente paciente, Medico medico, Especialidade especialidade)
        {
            Id = id;
            Data = data;
            Observacao = observacao;
            StatusConsulta = statusConsulta;
            Paciente = paciente;
            Medico = medico;
            Especialidade = especialidade;
        }

        public Guid Id { get; set; }
        public DateTime Data { get; set; }
        public string Observacao { get; set; }
        public StatusConsulta StatusConsulta { get; set; }
        public Paciente Paciente { get; set; }
        public Medico Medico { get; set; }
        public Especialidade Especialidade { get; set; }
        public Receita Receita { get; set; }
        public List<Atestado> Atestados { get; set; }
        public List<Exame> Exames { get; set; }
        public DateTime CriadoEm { get; set; }
        public string CriadoPor { get; set; }
        public string AtualizadoPor { get; set; }
        public DateTime? AtualizadoEm { get; set; }
    }
}
