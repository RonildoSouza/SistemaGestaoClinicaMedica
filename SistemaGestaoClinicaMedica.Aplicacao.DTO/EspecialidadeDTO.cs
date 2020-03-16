using System;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Aplicacao.DTO
{
    public class EspecialidadeDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public List<MedicoEspecialidadeDTO> Medicos { get; set; }
    }
}
