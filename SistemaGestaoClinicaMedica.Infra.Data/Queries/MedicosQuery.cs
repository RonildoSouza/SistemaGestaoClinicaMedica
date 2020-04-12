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

        public Medico ObterPorCRM(string crm)
        {
            return Entidades.Include(_ => _.Usuario)
                            .FirstOrDefault(_ => _.CRM.ToLower() == crm.ToLower());
        }

        public IList<Medico> ObterTudoPorEspecialidade(Guid especialidadeId)
        {
            var medicos = Entidades.Include(_ => _.Usuario)
                                   .Include($"{nameof(Medico.Especialidades)}.{nameof(MedicoEspecialidade.Especialidade)}")
                                   .Where(_ => _.Usuario.Ativo && _.Especialidades.Any(_ => _.EspecialidadeId == especialidadeId && _.Ativo))
                                   .ToList();

            return medicos;
        }

        public IDictionary<DateTime, bool> ObterHorariosDeTrabalhoAtivosIntervaloDeData(Guid medicoId, DateTime dataInicio, DateTime dataFim)
        {
            var dicionarioDatas = new Dictionary<DateTime, bool>();

            if (medicoId == Guid.Empty)
                return dicionarioDatas;

            var medicos = Entidades.Include(_ => _.Usuario)
                             .Where(_ => _.Id == medicoId || _.Usuario.Id == medicoId);

            while (dataInicio <= dataFim)
            {
                var trabalhaNesteDia = medicos
                    .Where(_ => _.HorariosDeTrabalho.Any(_ => _.DiaDaSemana == dataInicio.DayOfWeek && _.Ativo))
                    .Any();

                dicionarioDatas.Add(dataInicio, trabalhaNesteDia);
                dataInicio = dataInicio.AddDays(1);
            }

            return dicionarioDatas;
        }
    }
}
