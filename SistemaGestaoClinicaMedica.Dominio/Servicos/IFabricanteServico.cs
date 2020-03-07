using SistemaGestaoClinicaMedica.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Dominio.Servicos
{
    public interface IFabricanteServico : IServicoBase<Guid, Fabricante>
    {
        IList<Fabricante> ObterTudo(string nome);
    }
}
