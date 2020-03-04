﻿using SistemaGestaoClinicaMedica.Dominio.Entidades;
using System;
using System.Linq;

namespace SistemaGestaoClinicaMedica.Dominio.Servicos
{
    public interface IFabricanteServico : IServicoBase<Guid, Fabricante>
    {
        IQueryable<Fabricante> ObterTudo(string nome);
    }
}
