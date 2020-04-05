using SistemaGestaoClinicaMedica.Aplicacao.Interfaces.Email;
using SistemaGestaoClinicaMedica.Dominio.Documentos;
using SistemaGestaoClinicaMedica.Dominio.Documentos.Modelo;
using SistemaGestaoClinicaMedica.Infra.CrossCutting.Config.Servicos.Mail;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao.Email
{
    public sealed class EmailSenhaNovoUsuarioServicoAplicacao : IEmailSenhaNovoUsuarioServicoAplicacao
    {
        private readonly IEnviaEmail _enviaEmail;
        private readonly IConstroiDocumento _constroiDocumento;

        public EmailSenhaNovoUsuarioServicoAplicacao(IEnviaEmail enviaEmail, IConstroiDocumento constroiDocumento)
        {
            _enviaEmail = enviaEmail;
            _constroiDocumento = constroiDocumento;
        }

        public void Enviar(string usuarioEmail, string usuarioNome, string senha)
        {
            var assunto = "Novo Cadastro";
            var mensagem = $"Você acaba de ser cadastrado no Sistema de Gestão de Clinica Médica, para acessar utilize o email {usuarioEmail} e a senha {senha}.<br>" +
                $"Caso deseje alterar a senha, solicite ao administrador da clínica.";

            var mensagemHtml = _constroiDocumento.ConstroiTemplate(new EmailTemplate(
                assunto,
                usuarioNome,
                mensagem));

            _enviaEmail.Enviar(usuarioEmail, assunto, mensagemHtml);
        }
    }
}
