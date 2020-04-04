namespace SistemaGestaoClinicaMedica.Dominio.Documentos.Modelo
{
    public sealed class AtestadoComparecimentoTemplate : AtestadoTemplateBase
    {
        public AtestadoComparecimentoTemplate(string pacienteNome, string pacienteCPF, string medicoNome, string medicoCRM) : base("Atestado de Comparecimento", pacienteNome, pacienteCPF, medicoNome, medicoCRM)
        {
        }
    }
}
