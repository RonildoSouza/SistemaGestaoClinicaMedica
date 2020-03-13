using System;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Aplicacao.DTOS.Receita
{
    public class ReceitaEntradaDTO : IEntradaDTO<Guid>
    {
        public Guid Id { get; set; }
        public string Observacao { get; set; }
        public List<ReceitaMedicamentoEntradaDTO> ReceitaMedicamentos { get; set; }
        public Guid ConsultaId { get; set; }
    }
}
