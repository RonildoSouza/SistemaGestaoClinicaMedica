using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SistemaGestaoClinicaMedica.Aplicacao.DTO
{
    public class ConsultaDTO : IDTO<Guid>
    {
        public ConsultaDTO()
        {
            Receita = new ReceitaDTO();
        }

        public Guid Id { get; set; }
        public string Codigo { get; set; }
        [Required]
        public DateTime Data { get; set; }
        public string Observacao { get; set; }
        [Required]
        public string StatusConsultaId { get; set; }
        [Required]
        public Guid PacienteId { get; set; }
        [Required]
        public Guid MedicoId { get; set; }
        [Required]
        public Guid EspecialidadeId { get; set; }
        public List<ExameDTO> Exames { get; set; }
        public List<AtestadoDTO> Atestados { get; set; }
        public ReceitaDTO Receita { get; set; }

        public StatusConsultaDTO StatusConsulta { get; set; }
        public PacienteDTO Paciente { get; set; }
        public EspecialidadeDTO Especialidade { get; set; }
        public MedicoDTO Medico { get; set; }
    }
}
