namespace SistemaGestaoClinicaMedica.Infra.CrossCutting.Config.Servicos.Mail
{
    public interface IEnviaEmail
    {
        void Enviar(string destinatarioEmail, string assunto, string mensagem, bool mensagemEmHtml = true);
    }
}