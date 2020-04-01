using System;

namespace SistemaGestaoClinicaMedica.Aplicacao.DTO.Login
{
    public class LoginSaidaDTO
    {
        public LoginSaidaDTO() { }

        public LoginSaidaDTO(Guid id, bool autenticado, string criadoEm, string expiracao, string tokenDeAcesso)
        {
            Id = id;
            Autenticado = autenticado;
            CriadoEm = criadoEm;
            Expiracao = expiracao;
            Token = tokenDeAcesso;
        }

        public Guid Id { get; set; }
        public bool Autenticado { get; set; }
        public string CriadoEm { get; set; }
        public string Expiracao { get; set; }
        public string Token { get; set; }
    }
}