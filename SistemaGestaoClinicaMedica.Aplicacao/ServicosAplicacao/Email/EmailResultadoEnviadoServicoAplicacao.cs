using SistemaGestaoClinicaMedica.Aplicacao.Interfaces.Email;
using SistemaGestaoClinicaMedica.Dominio.Documentos;
using SistemaGestaoClinicaMedica.Dominio.Documentos.Modelo;
using SistemaGestaoClinicaMedica.Infra.CrossCutting.Config.Servicos.Mail;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao.Email
{
    public sealed class EmailResultadoEnviadoServicoAplicacao : IEmailResultadoEnviadoServicoAplicacao
    {
        private readonly IEnviaEmail _enviaEmail;
        private readonly IConstroiDocumento _constroiDocumento;

        public EmailResultadoEnviadoServicoAplicacao(IEnviaEmail enviaEmail, IConstroiDocumento constroiDocumento)
        {
            _enviaEmail = enviaEmail;
            _constroiDocumento = constroiDocumento;
        }

        public void Enviar(string medicoEmail, string medicoNome, string exameCodigo)
        {
            var assunto = "Resultado de Exame";
            var mensagem = $"O resultado laboratorial do exame de código {exameCodigo} foi enviado!<br>" +
                $"Acesse o menu \"Consultar Exames\" para baixar o arquivo";

            var mensagemHtml = _constroiDocumento.ConstroiTemplate(new EmailTemplate(
                assunto,
                medicoNome,
                mensagem));

            _enviaEmail.Enviar(medicoEmail, assunto, mensagemHtml);
        }
    }
}
