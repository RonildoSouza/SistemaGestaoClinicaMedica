using System;

namespace SistemaGestaoClinicaMedica.Infra.CrossCutting.Config.Modelos
{
    public class AutenticacaoEntrada
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string CargoId { get; set; }
        public string Email { get; set; }
    }
}