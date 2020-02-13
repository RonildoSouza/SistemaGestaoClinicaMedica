namespace SistemaGestaoClinicaMedica.Dominio.Entidades
{
    public class Cargo : IEntidade<string>
    {
        public string Id { get; set; }
        public string Nome { get; set; }
    }
}