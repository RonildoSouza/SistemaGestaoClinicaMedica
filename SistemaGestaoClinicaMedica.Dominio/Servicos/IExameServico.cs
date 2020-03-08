using SistemaGestaoClinicaMedica.Dominio.Entidades;
using System;

namespace SistemaGestaoClinicaMedica.Dominio.Servicos
{
    public interface IExameServico : IServicoBase<Guid, Exame>
    {
        Exame Obter(string codigo);
    }
}
