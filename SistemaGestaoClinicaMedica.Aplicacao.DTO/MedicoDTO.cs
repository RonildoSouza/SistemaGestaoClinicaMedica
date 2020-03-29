using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Aplicacao.DTO
{
    public class MedicoDTO : UsuarioDTO
    {
        public string CRM { get; set; }
        public List<HorarioDeTrabalhoDTO> HorariosDeTrabalho { get; set; }
        public List<MedicoEspecialidadeDTO> Especialidades { get; set; }
    }
}
