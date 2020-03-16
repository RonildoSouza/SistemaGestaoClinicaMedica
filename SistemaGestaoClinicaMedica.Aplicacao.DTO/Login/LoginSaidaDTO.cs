namespace SistemaGestaoClinicaMedica.Aplicacao.DTO.Login
{
    public class LoginSaidaDTO
    {
        public LoginSaidaDTO(bool autenticado, string criadoEm, string expiracao, string tokenDeAcesso)
        {
            Autenticado = autenticado;
            CriadoEm = criadoEm;
            Expiracao = expiracao;
            TokenDeAcesso = tokenDeAcesso;
        }

        public bool Autenticado { get; set; }
        public string CriadoEm { get; set; }
        public string Expiracao { get; set; }
        public string TokenDeAcesso { get; set; }
    }
}