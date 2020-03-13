using System;

namespace SistemaGestaoClinicaMedica.Aplicacao.DTOS.Paciente
{
    public class PacienteSaidaDTO
    {
        public Guid Id { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public bool Ativo { get; set; }
        public string Endereco { get; set; }
    }
}
