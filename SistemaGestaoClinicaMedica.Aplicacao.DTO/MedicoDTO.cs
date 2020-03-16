using System;

namespace SistemaGestaoClinicaMedica.Aplicacao.DTO
{
    public class MedicoDTO : IDTO<Guid>
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string CRM { get; set; }
    }
}
