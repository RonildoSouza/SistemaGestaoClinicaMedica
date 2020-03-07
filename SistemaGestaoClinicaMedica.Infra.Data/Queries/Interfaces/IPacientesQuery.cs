using SistemaGestaoClinicaMedica.Dominio.Entidades;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Infra.Data.Queries
{
    public interface IPacientesQuery : IQueryBase<Paciente>
    {
        IList<Paciente> ObterTudo(string busca, bool ativo);
    }
}
