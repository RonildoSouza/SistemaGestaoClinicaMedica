using System;

namespace SistemaGestaoClinicaMedica.Aplicacao.DTOS.Consulta
{
    public class ConsultaEntradaDTO : IEntradaDTO<Guid>
    {
        public Guid Id { get; set; }
        public DateTime Data { get; set; }
        public string Observacao { get; set; }
        public string StatusConsultaId { get; set; }
        public string PacienteId { get; set; }
        public string MedicoId { get; set; }
        public string EspecialidadeId { get; set; }
    }
}
