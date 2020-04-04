namespace SistemaGestaoClinicaMedica.Dominio.Documentos.Modelo
{
    public sealed class AtestadoAptidaoFisicaTemplate : AtestadoTemplateBase
    {
        public AtestadoAptidaoFisicaTemplate(string pacienteNome, string pacienteCPF, string medicoNome, string medicoCRM) : base("Atestado de Aptidão Física", pacienteNome, pacienteCPF, medicoNome, medicoCRM)
        {
        }
    }
}
