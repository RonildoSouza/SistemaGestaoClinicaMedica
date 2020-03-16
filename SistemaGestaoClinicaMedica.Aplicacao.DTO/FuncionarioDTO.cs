using System;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Aplicacao.DTO
{
    public class FuncionarioDTO : IDTO<Guid>
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Senha { get; set; }
        public string CargoId { get; set; }
        public string CRM { get; set; }
        public bool DaClinica { get; set; }
        public bool Ativo { get; set; }
        public List<HorarioDeTrabalhoDTO> HorariosDeTrabalho { get; set; }
        public List<MedicoEspecialidadeDTO> MedicoEspecialidades { get; set; }
    }
}
