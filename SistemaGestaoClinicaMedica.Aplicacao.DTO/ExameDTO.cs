using System;

namespace SistemaGestaoClinicaMedica.Aplicacao.DTO
{
    public class ExameDTO : IDTO<Guid>
    {
        public Guid Id { get; set; }
        public string Codigo { get; set; }
        public Guid TipoDeExameId { get; set; }
        public string Observacao { get; set; }
        public string StatusExameId { get; set; }
        public Guid? LaboratorioRealizouExameId { get; set; }
        public Guid ConsultaId { get; set; }
        public string LinkResultadoExame { get; set; }

        public TipoDeExameDTO TipoDeExame { get; set; }
        public StatusExameDTO StatusExame { get; set; }
        public LaboratorioSaidaDTO LaboratorioRealizouExame { get; set; }
    }
}
