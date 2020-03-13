using System;

namespace SistemaGestaoClinicaMedica.Aplicacao.DTOS.Funcionario.Medico
{
    public class MedicoEspecialidadeSaidaDTO
    {
        public Guid MedicoId { get; set; }
        public string Nome { get; set; }
        public string CRM { get; set; }
    }
}
