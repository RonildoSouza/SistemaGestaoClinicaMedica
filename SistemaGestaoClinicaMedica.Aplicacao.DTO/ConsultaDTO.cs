using System;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Aplicacao.DTO
{
    public class ConsultaDTO : IDTO<Guid>
    {
        public Guid Id { get; set; }
        public string Codigo { get; set; }
        public DateTime Data { get; set; }
        public string Observacao { get; set; }
        public string StatusConsultaId { get; set; }
        public Guid PacienteId { get; set; }
        public Guid MedicoId { get; set; }
        public Guid EspecialidadeId { get; set; }
        public List<ExameDTO> Exames { get; set; }
        public List<AtestadoDTO> Atestados { get; set; }
        public ReceitaDTO Receita { get; set; }
    }
}
