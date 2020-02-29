﻿using SistemaGestaoClinicaMedica.Dominio.Entidades;
using System;
using System.Linq;

namespace SistemaGestaoClinicaMedica.Dominio.Servicos
{
    public interface IEspecialidadeServico : IServicoBase<Guid, Especialidade>
    {
        IQueryable<Especialidade> ObterTudo(bool comMedicos = false);
    }
}
