using SistemaGestaoClinicaMedica.Dominio.Entidades;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Infra.Data.Queries
{
    public interface IEspecialidadesQuery : IQueryBase<Especialidade>
    {
        IList<Especialidade> ObterDisponiveis();
        IList<Especialidade> ObterTudoComFiltros(bool comMedicos);
    }
}
