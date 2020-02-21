namespace SistemaGestaoClinicaMedica.Infra.CrossCutting.Config.Modelos
{
    public class AutenticacaoSaida
    {
        public bool Sucesso { get; set; }
        public bool Autenticado { get; set; }
        public string CriadoEm { get; set; }
        public string Expiracao { get; set; }
        public string TokenDeAcesso { get; set; }
    }
}