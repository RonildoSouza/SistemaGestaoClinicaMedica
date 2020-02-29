using Microsoft.EntityFrameworkCore;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using System.Linq;

namespace SistemaGestaoClinicaMedica.Infra.Data.Queries
{
    public class EspecialidadesQuery : QueryBase, IEspecialidadesQuery
    {
        public IQueryable<Especialidade> ObterTudo(bool comMedicos = false)
        {
            if (comMedicos)
                return ContextoBancoDados.Especialidades.Include(_ => _.Medicos)
                                                        .Include($"{nameof(Especialidade.Medicos)}.{nameof(MedicoEspecialidade.Medico)}")
                                                        .Include($"{nameof(Especialidade.Medicos)}.{nameof(MedicoEspecialidade.Medico)}.{nameof(Medico.Funcionario)}")
                                                        .OrderBy(_ => _.Nome)
                                                        .AsQueryable();

            return ContextoBancoDados.Especialidades.AsQueryable();
        }
    }
}
