namespace SistemaGestaoClinicaMedica.Dominio.Entidades
{
    public class StatusConsulta : IEntidade<string>
    {
        public string Id { get; set; }
        public string Nome { get; set; }
    }
}