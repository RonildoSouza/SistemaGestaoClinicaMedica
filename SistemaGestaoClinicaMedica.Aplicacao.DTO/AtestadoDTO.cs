using System;

namespace SistemaGestaoClinicaMedica.Aplicacao.DTO
{
    public class AtestadoDTO : IDTO<Guid>
    {
        public AtestadoDTO()
        {
            TipoDeAtestado = new TipoDeAtestadoDTO();
        }

        public Guid Id { get; set; }
        public string Observacao { get; set; }
        public TipoDeAtestadoDTO TipoDeAtestado { get; set; }
        public Guid ConsultaId { get; set; }
    }
}
