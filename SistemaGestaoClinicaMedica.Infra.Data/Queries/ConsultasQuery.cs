using Microsoft.EntityFrameworkCore;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaGestaoClinicaMedica.Infra.Data.Queries
{
    public class ConsultasQuery : QueryBase<Consulta>, IConsultasQuery
    {
        public ConsultasQuery(ContextoBancoDados contextoBancoDados) : base(contextoBancoDados)
        {
        }

        public Consulta Obter(Guid id, bool comExames, bool comAtestados)
        {
            var dbset = Entidades.Include(_ => _.Paciente)
                                 .Include(_ => _.StatusConsulta)
                                 .Include(_ => _.Medico)
                                 .Include($"{nameof(Consulta.Medico)}.{nameof(Medico.Funcionario)}")
                                 .Include(_ => _.Especialidade)
                                 .AsQueryable();

            if (comExames)
                dbset = dbset.Include(_ => _.Exames)
                             .Include($"{nameof(Consulta.Exames)}.{nameof(Exame.TipoDeExame)}")
                             .Include($"{nameof(Consulta.Exames)}.{nameof(Exame.StatusExame)}")
                             .Include($"{nameof(Consulta.Exames)}.{nameof(Exame.LaboratorioRealizouExame)}")
                             .Include($"{nameof(Consulta.Exames)}.{nameof(Exame.LaboratorioRealizouExame)}.{nameof(Laboratorio.Funcionario)}")
                             .AsQueryable();

            if (comAtestados)
                dbset = dbset.Include(_ => _.Atestados)
                             .Include($"{nameof(Consulta.Atestados)}.{nameof(Atestado.TipoDeAtestado)}")
                             .AsQueryable();

            return dbset.FirstOrDefault(_ => _.Id == id);
        }

        public IList<Consulta> ObterTudo(DateTime dataInicio, DateTime dataFim, string busca, EStatusConsulta? status)
        {
            if (dataInicio == default && dataFim == default)
            {
                dataInicio = DateTime.Today;
                dataFim = DateTime.Today.AddMonths(1);
            }

            var consultas = Entidades.Include(_ => _.Paciente)
                                     .Include(_ => _.StatusConsulta)
                                     .Include(_ => _.Medico)
                                     .Include(_ => _.Especialidade)
                                     .Include($"{nameof(Consulta.Medico)}.{nameof(Medico.Funcionario)}")
                                     .Where(_ => _.Data >= dataInicio && _.Data <= dataFim).ToList();

            if (!string.IsNullOrEmpty(busca))
                consultas = consultas.Where(_ => _.Medico.Funcionario.Nome.ToLowerContains(busca)
                                                 || _.Paciente.Nome.ToLowerContains(busca)
                                                 || _.Paciente.Id.ToString().ToLowerStartsWith(busca)
                                                 || _.Id.ToString().ToLowerStartsWith(busca)).ToList();

            if (!string.IsNullOrEmpty(status?.ToString()))
                consultas = consultas.Where(_ => _.StatusConsulta.Id.ToString().ToLowerEquals(status.Value.ToString())).ToList();

            return consultas;
        }
    }
}
