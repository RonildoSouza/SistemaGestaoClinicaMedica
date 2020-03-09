using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Atestado;
using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Exame;
using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Funcionario.Medico;
using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Paciente;
using System;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Aplicacao.DTOS.Consulta
{
    public class ConsultaSaidaDTO
    {
        public Guid Id { get; set; }
        public string Codigo { get; set; }
        public DateTime Data { get; set; }
        public string Observacao { get; set; }
        public string StatusConsulta { get; set; }
        public PacienteSaidaDTO Paciente { get; set; }
        public MedicoSaidaDTO Medico { get; set; }
        public string Especialidade { get; set; }
        public List<ExameSaidaDTO> Exames { get; set; }
        public List<AtestadoSaidaDTO> Atestados { get; set; }
    }
}
