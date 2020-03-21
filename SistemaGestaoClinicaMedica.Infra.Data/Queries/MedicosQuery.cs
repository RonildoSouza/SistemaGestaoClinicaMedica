using Microsoft.EntityFrameworkCore;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaGestaoClinicaMedica.Infra.Data.Queries
{
    public class MedicosQuery : QueryBase<Medico>, IMedicosQuery
    {
        public MedicosQuery(ContextoBancoDados contextoBancoDados) : base(contextoBancoDados)
        {
        }

        public IList<Medico> ObterTudoPorEspecialidade(Guid especialidadeId)
        {
            var medicos = Entidades.Include(_ => _.Funcionario)
                                   .Include($"{nameof(Medico.Especialidades)}.{nameof(MedicoEspecialidade.Especialidade)}")
                                   .Where(_ => _.Funcionario.Ativo && _.Especialidades.Any(_ => _.EspecialidadeId == especialidadeId))
                                   .ToList();

            return medicos;
        }
    }
}
