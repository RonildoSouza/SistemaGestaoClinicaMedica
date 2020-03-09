using System;

namespace SistemaGestaoClinicaMedica.Aplicacao.DTOS.Atestado
{
    public class AtestadoSaidaDTO
    {
        public Guid Id { get; set; }
        public string Observacao { get; set; }
        public TipoDeAtestadoSaidaDTO TipoDeAtestado { get; set; }
        public Guid ConsultaId { get; set; }
    }
}
