﻿using System;

namespace SistemaGestaoClinicaMedica.Aplicacao.DTO
{
    public class MedicoEspecialidadeDTO : IDTO<Guid>
    {
        public Guid Id { get; set; }
        public Guid EspecialidadeId { get; set; }
        public MedicoDTO Medico { get; set; }
    }
}
