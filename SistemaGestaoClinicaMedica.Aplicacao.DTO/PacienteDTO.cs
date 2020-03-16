using System;

namespace SistemaGestaoClinicaMedica.Aplicacao.DTO
{
    public class PacienteDTO : IDTO<Guid>
    {
        public Guid Id { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Endereco => $"{Bairro}, {Cidade} - {Estado}";
        public bool Ativo { get; set; }
    }
}
