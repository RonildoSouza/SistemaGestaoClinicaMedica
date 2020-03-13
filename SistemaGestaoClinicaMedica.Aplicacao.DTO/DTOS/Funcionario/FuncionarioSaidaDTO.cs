using System;

namespace SistemaGestaoClinicaMedica.Aplicacao.DTOS.Funcionario
{
    public class FuncionarioSaidaDTO
    {
        public FuncionarioSaidaDTO(Guid id, string nome, string email, string cargoId, bool ativo)
        {
            Id = id;
            Nome = nome;
            Email = email;
            CargoId = cargoId;
            Ativo = ativo;
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string CargoId { get; set; }
        public bool Ativo { get; set; }
    }
}
