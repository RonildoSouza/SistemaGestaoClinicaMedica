using SistemaGestaoClinicaMedica.Apresentacao.Site.Constantes;
using System;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Modelo
{
    public class UsuarioLogado
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string CargoId { get; set; }
        public string Email { get; set; }
        public bool EAdministrador => CargoId == CargosConst.Administrador;
        public bool EMedico => CargoId == CargosConst.Medico;
    }
}
