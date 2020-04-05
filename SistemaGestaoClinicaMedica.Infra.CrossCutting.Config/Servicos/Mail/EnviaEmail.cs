using Microsoft.Extensions.DependencyInjection;
using System.Net.Mail;

namespace SistemaGestaoClinicaMedica.Infra.CrossCutting.Config.Servicos.Mail
{
    public class EnviaEmail : IEnviaEmail
    {
        private MailMessage _mailMessage;
        private MailAddress _mailAddress;
        private SmtpClient _smtpClient;

        public EnviaEmail(MailMessage mailMessage, MailAddress mailAddress, SmtpClient smtpClient)
        {
            _mailMessage = mailMessage;
            _mailAddress = mailAddress;
            _smtpClient = smtpClient;
        }

        public void Enviar(string destinatarioEmail, string assunto, string mensagem, bool mensagemEmHtml = true)
        {
            _mailMessage.From = _mailAddress;
            _mailMessage.To.Add(destinatarioEmail);
            _mailMessage.IsBodyHtml = mensagemEmHtml;
            _mailMessage.Subject = assunto;
            _mailMessage.Body = mensagem;

            _smtpClient.Send(_mailMessage);
        }
    }

    public static class EnviaEmailExtension
    {
        public static void AddEnviaEmail(
            this IServiceCollection services,
            string remetenteEmail,
            string remetenteNome,
            string servidorSmtp,
            int portaSmtp)
        {
            services.AddScoped<MailMessage>();
            services.AddSingleton(new MailAddress(remetenteEmail, remetenteNome));
            services.AddSingleton(new SmtpClient(servidorSmtp, portaSmtp));
            services.AddScoped(typeof(IEnviaEmail), typeof(EnviaEmail));
        }
    }
}