namespace SistemaGestaoClinicaMedica.Dominio.Documentos.Modelo
{
    public sealed class EmailTemplate
    {
        public EmailTemplate(string assunto, string destinatarioNome, string mensagem)
        {
            Assunto = assunto;
            DestinatarioNome = destinatarioNome;
            Mensagem = mensagem;
        }

        public string Assunto { get; set; }
        public string DestinatarioNome { get; set; }
        public string Mensagem { get; set; }
    }
}
