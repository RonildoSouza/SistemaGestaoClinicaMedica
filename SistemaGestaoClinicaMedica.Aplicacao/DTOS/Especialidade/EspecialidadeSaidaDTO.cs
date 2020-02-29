using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Funcionario.Medico;
using System;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Aplicacao.DTOS.Especialidade
{
    public class EspecialidadeSaidaDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public List<MedicoEspecialidadeSaidaDTO> Medicos { get; set; }
    }
}
