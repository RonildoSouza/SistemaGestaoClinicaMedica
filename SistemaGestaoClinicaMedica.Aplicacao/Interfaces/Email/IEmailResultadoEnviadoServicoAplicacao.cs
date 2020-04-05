namespace SistemaGestaoClinicaMedica.Aplicacao.Interfaces.Email
{
    public interface IEmailResultadoEnviadoServicoAplicacao
    {
        void Enviar(string medicoEmail, string medicoNome, string exameCodigo);
    }
}
