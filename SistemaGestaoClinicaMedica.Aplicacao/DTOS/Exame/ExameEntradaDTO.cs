using System;

namespace SistemaGestaoClinicaMedica.Aplicacao.DTOS.Exame
{
    public class ExameEntradaDTO : IEntradaDTO<Guid>
    {
        public Guid Id { get; set; }
        public Guid TipoDeExameId { get; set; }
        public string Observacao { get; set; }
        public string StatusExameId { get; set; }
        public Guid? LaboratorioRealizouExameId { get; set; }
        public Guid ConsultaId { get; set; }
        public string LinkResultadoExame { get; set; }
    }
}
