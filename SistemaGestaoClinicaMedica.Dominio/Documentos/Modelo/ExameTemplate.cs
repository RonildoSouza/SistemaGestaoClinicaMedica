using System;

namespace SistemaGestaoClinicaMedica.Dominio.Documentos.Modelo
{
    public sealed class ExameTemplate
    {
        public ExameTemplate(string consultaCodigo, string pacienteNome, string pacienteDataNascimento, string pacienteSexo, string medicoNome, string medicoCRM, string tipoDeExameNome)
        {
            ConsultaCodigo = consultaCodigo;
            PacienteNome = pacienteNome.ToUpper();
            PacienteDataNascimento = pacienteDataNascimento;
            PacienteSexo = pacienteSexo.ToUpper();
            MedicoNome = medicoNome.ToUpper();
            MedicoCRM = medicoCRM.ToUpper();
            TipoDeExameNome = tipoDeExameNome;
        }

        public string ConsultaCodigo { get; set; }
        public string PacienteNome { get; set; }
        public string PacienteDataNascimento { get; set; }
        public string PacienteSexo { get; set; }
        public string MedicoNome { get; set; }
        public string MedicoCRM { get; set; }
        public string TipoDeExameNome { get; set; }
        public string DataAtual => DateTime.Now.ToString("dd/MM/yyyy");
    }
}
