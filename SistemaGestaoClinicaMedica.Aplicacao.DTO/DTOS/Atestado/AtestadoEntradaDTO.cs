using System;

namespace SistemaGestaoClinicaMedica.Aplicacao.DTOS.Atestado
{
    public class AtestadoEntradaDTO : IEntradaDTO<Guid>
    {
        public Guid Id { get; set; }
        public string Observacao { get; set; }
        public string TipoDeAtestadoId { get; set; }
        public Guid ConsultaId { get; set; }
    }
}
