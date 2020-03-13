using System;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Aplicacao.DTOS.Receita
{
    public class ReceitaSaidaDTO
    {
        public Guid Id { get; set; }
        public string Observacao { get; set; }
        public List<ReceitaMedicamentoSaidaDTO> ReceitaMedicamentos { get; set; }
        public Guid ConsultaId { get; set; }
    }
}
