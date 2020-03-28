using System;

namespace SistemaGestaoClinicaMedica.Aplicacao.DTO
{
    public class ExameDTO : IDTO<Guid>
    {
        public ExameDTO()
        {
            TipoDeExame = new TipoDeExameDTO();
            StatusExame = new StatusExameDTO();
        }

        public Guid Id { get; set; }
        public string Codigo { get; set; }
        public TipoDeExameDTO TipoDeExame { get; set; }
        public string Observacao { get; set; }
        public StatusExameDTO StatusExame { get; set; }
        public Guid? LaboratorioRealizouExameId { get; set; }
        public Guid ConsultaId { get; set; }
        public string LinkResultadoExame { get; set; }
        public LaboratorioDTO LaboratorioRealizouExame { get; set; }
    }
}
