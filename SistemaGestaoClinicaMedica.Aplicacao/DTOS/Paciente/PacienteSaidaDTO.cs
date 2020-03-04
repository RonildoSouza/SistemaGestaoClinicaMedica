using System;

namespace SistemaGestaoClinicaMedica.Aplicacao.DTOS.Paciente
{
    public class PacienteSaidaDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
    }
}
