namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Documentos.Modelo
{
    public sealed class ReceitaTemplate
    {
        public ReceitaTemplate(string consultaCodigo, string pacienteNome, string pacienteDataNascimento, string medicoNome, string medicoCRM, string medicamentos)
        {
            ConsultaCodigo = consultaCodigo;
            PacienteNome = pacienteNome;
            PacienteDataNascimento = pacienteDataNascimento;
            MedicoNome = medicoNome;
            MedicoCRM = medicoCRM;
            Medicamentos = medicamentos;
        }

        public string ConsultaCodigo { get; set; }
        public string PacienteNome { get; set; }
        public string PacienteDataNascimento { get; set; }
        public string MedicoNome { get; set; }
        public string MedicoCRM { get; set; }
        public string Medicamentos { get; set; }
    }
}
