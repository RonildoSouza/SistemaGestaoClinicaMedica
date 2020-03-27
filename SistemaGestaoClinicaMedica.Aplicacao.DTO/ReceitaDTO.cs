using System;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Aplicacao.DTO
{
    public class ReceitaDTO : IDTO<Guid>
    {
        public ReceitaDTO()
        {
            ReceitaMedicamentos = new List<ReceitaMedicamentoDTO>();
        }

        public Guid Id { get; set; }
        public string Observacao { get; set; }
        public List<ReceitaMedicamentoDTO> ReceitaMedicamentos { get; set; }
        public Guid ConsultaId { get; set; }
    }
}
