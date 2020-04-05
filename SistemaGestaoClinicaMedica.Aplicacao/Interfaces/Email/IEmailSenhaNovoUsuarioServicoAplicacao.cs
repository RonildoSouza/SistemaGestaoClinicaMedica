namespace SistemaGestaoClinicaMedica.Aplicacao.Interfaces.Email
{
    public interface IEmailSenhaNovoUsuarioServicoAplicacao
    {
        void Enviar(string usuarioEmail, string usuarioNome, string senha);
    }
}
