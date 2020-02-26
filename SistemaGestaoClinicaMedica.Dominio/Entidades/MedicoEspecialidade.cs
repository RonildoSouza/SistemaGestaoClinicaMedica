using System;

namespace SistemaGestaoClinicaMedica.Dominio.Entidades
{
    public class MedicoEspecialidade : IEntidade<Guid>
    {
        public Guid Id { get; set; }

        public Guid MedicoId { get; set; }
        public Medico Medico { get; set; }

        public Guid EspecialidadeId { get; set; }
        public Especialidade Especialidade { get; set; }
    }
}
