using SistemaGestaoClinicaMedica.Dominio.Entidades;
using System.Linq;

namespace SistemaGestaoClinicaMedica.Infra.Data.Queries
{
    public interface IEspecialidadesQuery : IQueryBase
    {
        IQueryable<Especialidade> ObterTudo(bool comMedicos = false);
    }
}
