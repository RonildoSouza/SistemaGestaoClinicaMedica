﻿using SistemaGestaoClinicaMedica.Dominio.Entidades;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Infra.Data.Queries
{
    public interface IFabricantesQuery : IQueryBase<Fabricante>
    {
        IList<Fabricante> ObterTudo(string nome);
    }
}