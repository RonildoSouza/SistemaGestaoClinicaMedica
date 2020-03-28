using System;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Dominio.Entidades
{
    public class Medico : IEntidade<Guid>
    {
        public Medico() { }

        public Medico(string crm, Usuario usuario, List<HorarioDeTrabalho> horariosDeTrabalho, List<MedicoEspecialidade> especialidades)
        {
            CRM = crm;
            Usuario = usuario;
            HorariosDeTrabalho = horariosDeTrabalho;
            Especialidades = especialidades;
        }

        public Guid Id { get; set; }
        public string CRM { get; set; }

        public Usuario Usuario { get; set; }
        public List<HorarioDeTrabalho> HorariosDeTrabalho { get; set; }
        public List<MedicoEspecialidade> Especialidades { get; set; }
    }
}
