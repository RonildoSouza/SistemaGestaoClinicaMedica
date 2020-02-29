using SistemaGestaoClinicaMedica.Aplicacao.DTOS.HorarioDeTrabalho;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Aplicacao.DTOS.Funcionario
{
    public class FuncionarioEntradaDTO
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Senha { get; set; }
        public string CargoId { get; set; }
        public string CRM { get; set; }
        public List<HorarioDeTrabalhoEntradaDTO> HorariosDeTrabalho { get; set; }
        //public List<HorarioDeTrabalhoEntradaDTO> HorariosDeTrabalho { get; set; }
    }
}
