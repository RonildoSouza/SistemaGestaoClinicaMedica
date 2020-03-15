using SistemaGestaoClinicaMedica.Dominio.Entidades;
using System;

namespace SistemaGestaoClinicaMedica.Dominio.Servicos
{
    public interface IFabricanteServico : IServicoBase<Guid, Fabricante>
    {
        Fabricante Obter(string nome);
    }
}
