using System;
using System.ComponentModel.DataAnnotations;

namespace SistemaGestaoClinicaMedica.Aplicacao.DTO
{
    public class PacienteDTO : IDTO<Guid>
    {
        public Guid Id { get; set; }
        public string Codigo { get; set; }
        [Required]
        [MinLength(11), MaxLength(14)]
        public string CPF { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public DateTime DataNascimento { get; set; }
        [Required]
        public string NomeDaMae { get; set; }
        [Required]
        public string Sexo { get; set; } = "Feminino";
        [Required]
        public string Telefone { get; set; }
        [Required]
        public string Bairro { get; set; }
        [Required]
        public string Cidade { get; set; }
        [Required]
        public string Estado { get; set; }
        public string Endereco => $"{Bairro}, {Cidade} - {Estado}";
        public bool Ativo { get; set; } = true;
    }
}
