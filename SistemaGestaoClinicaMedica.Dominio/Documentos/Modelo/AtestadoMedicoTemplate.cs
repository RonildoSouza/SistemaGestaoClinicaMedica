namespace SistemaGestaoClinicaMedica.Dominio.Documentos.Modelo
{
    public sealed class AtestadoMedicoTemplate : AtestadoTemplateBase
    {
        private readonly bool _temRepouso;

        public AtestadoMedicoTemplate(string tipoAtestadoNome, string pacienteNome, string pacienteCPF, string medicoNome, string medicoCRM, bool temRepouso = true) : base(tipoAtestadoNome, pacienteNome, pacienteCPF, medicoNome, medicoCRM)
        {
            _temRepouso = temRepouso;
        }

        public string Repouso => _temRepouso ? "e necessitando de ____ dia(s) de repouso" : string.Empty;
    }
}
