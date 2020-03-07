using System;

namespace SistemaGestaoClinicaMedica.Aplicacao.DTOS.Paciente
{
    public class PacienteEntradaDTO : IEntradaDTO<Guid>
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public bool Ativo { get; set; }
    }
}
