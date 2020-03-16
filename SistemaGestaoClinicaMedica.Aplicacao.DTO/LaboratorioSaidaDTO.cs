using System;

namespace SistemaGestaoClinicaMedica.Aplicacao.DTO
{
    public class LaboratorioSaidaDTO : IDTO<Guid>
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public bool DaClinica { get; set; }
    }
}
