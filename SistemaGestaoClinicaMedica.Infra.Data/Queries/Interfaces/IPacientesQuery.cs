using SistemaGestaoClinicaMedica.Dominio.Entidades;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Infra.Data.Queries
{
    public interface IPacientesQuery : IQueryBase<Paciente>
    {
        Paciente ObterPorCodigo(string pacienteCodigo);
        IList<Paciente> ObterTudoComFiltros(string busca, bool ativo);
    }
}
