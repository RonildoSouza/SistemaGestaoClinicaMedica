using System;

namespace SistemaGestaoClinicaMedica.Infra.CrossCutting.Config.Modelos
{
    public class AutenticacaoEntrada
    {
        public AutenticacaoEntrada(Guid id, string nome, string cargoId, string email)
        {
            Id = id;
            Nome = nome;
            CargoId = cargoId;
            Email = email;
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string CargoId { get; set; }
        public string Email { get; set; }
    }
}