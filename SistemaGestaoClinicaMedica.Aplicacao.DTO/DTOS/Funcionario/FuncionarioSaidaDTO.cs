using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Cargo;
using System;

namespace SistemaGestaoClinicaMedica.Aplicacao.DTOS.Funcionario
{
    public class FuncionarioSaidaDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public CargoSaidaDTO Cargo { get; set; }
        public bool Ativo { get; set; }
    }
}
