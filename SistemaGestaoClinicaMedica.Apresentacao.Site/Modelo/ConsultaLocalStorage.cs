using System;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Modelo
{
    public sealed class ConsultaLocalStorage
    {
        public DateTime Data { get; set; }
        public PacienteLocalStorage Paciente { get; set; }
        public EspecialidadeLocalStorage Especialidade { get; set; }
        public MedicoLocalStorage Medico { get; set; }
    }
}