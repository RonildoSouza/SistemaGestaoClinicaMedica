using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Dominio.Entidades
{
    public class Medico : Funcionario
    {
        public string CRM { get; set; }
        public List<HorarioDeTrabalho> HorariosDeTrabalho { get; set; }
        public List<Especialidade> Especialidades{ get; set; }
    }
}
