namespace SistemaGestaoClinicaMedica.Infra.CrossCutting.Config.Modelos
{
    public sealed class EmailConfig
    {
        public string Smtp { get; set; }
        public int PortaSmtp { get; set; }
        public string RemetenteNome { get; set; }
        public string RemetenteEmail { get; set; }
    }
}
