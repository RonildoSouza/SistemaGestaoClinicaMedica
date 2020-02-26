namespace SistemaGestaoClinicaMedica.Dominio.Entidades
{
    public class Cargo : IEntidade<string>
    {
        public Cargo() { }

        public Cargo(string id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public string Id { get; set; }
        public string Nome { get; set; }
    }
}