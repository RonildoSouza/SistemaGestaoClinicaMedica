using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Funcionario.Medico;
using System;

namespace SistemaGestaoClinicaMedica.Aplicacao.DTOS.Exame
{
    public class ExameSaidaDTO
    {
        public Guid Id { get; set; }
        public TipoDeExameSaidaDTO TipoDeExame { get; set; }
        public string Codigo { get; set; }
        public string Observacao { get; set; }
        public string StatusExame { get; set; }
        public LaboratorioSaidaDTO LaboratorioRealizouExame { get; set; }
    }
}
