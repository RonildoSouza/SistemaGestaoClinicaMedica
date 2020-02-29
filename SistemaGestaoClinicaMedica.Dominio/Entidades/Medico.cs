using System;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Dominio.Entidades
{
    public class Medico : IEntidade<Guid>
    {
        public Medico() { }

        public Medico(string crm, Funcionario funcionario, List<HorarioDeTrabalho> horariosDeTrabalho, List<MedicoEspecialidade> especialidades)
        {
            CRM = crm;
            Funcionario = funcionario;
            HorariosDeTrabalho = horariosDeTrabalho;
            Especialidades = especialidades;
        }

        public Guid Id { get; set; }
        public string CRM { get; set; }

        public Funcionario Funcionario { get; set; }
        public List<HorarioDeTrabalho> HorariosDeTrabalho { get; set; }
        public List<MedicoEspecialidade> Especialidades { get; set; }
    }
}
