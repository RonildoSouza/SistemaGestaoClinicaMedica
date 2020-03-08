using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Funcionario.Medico;
using System;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Aplicacao.DTOS.Funcionario
{
    public class FuncionarioEntradaDTO : IEntradaDTO<Guid>
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
        public List<HorarioDeTrabalhoEntradaDTO> HorariosDeTrabalho { get; set; }
        public List<MedicoEspecialidadeEntradaDTO> MedicoEspecialidades { get; set; }
    }
}
