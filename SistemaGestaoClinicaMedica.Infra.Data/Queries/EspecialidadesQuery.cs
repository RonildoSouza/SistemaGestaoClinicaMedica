using Microsoft.EntityFrameworkCore;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace SistemaGestaoClinicaMedica.Infra.Data.Queries
{
    public class EspecialidadesQuery : QueryBase<Especialidade>, IEspecialidadesQuery
    {
        public EspecialidadesQuery(ContextoBancoDados contextoBancoDados) : base(contextoBancoDados)
        {
        }

        public IList<Especialidade> ObterTudo(bool comMedicos = false)
        {
            if (comMedicos)
                return Entidades.Include(_ => _.Medicos)
                                .Include($"{nameof(Especialidade.Medicos)}.{nameof(MedicoEspecialidade.Medico)}")
                                .Include($"{nameof(Especialidade.Medicos)}.{nameof(MedicoEspecialidade.Medico)}.{nameof(Medico.Funcionario)}")
                                .OrderBy(_ => _.Nome)
                                .ToList();

            return Entidades.ToList();
        }
    }
}
