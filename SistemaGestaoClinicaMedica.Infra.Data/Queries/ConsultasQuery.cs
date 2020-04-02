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

        public Consulta ObterComFiltros(Guid id, bool comExames, bool comAtestados)
        {
            var dbset = Entidades.Include(_ => _.Paciente)
                                 .Include(_ => _.StatusConsulta)
                                 .Include(_ => _.Medico)
                                 .Include($"{nameof(Consulta.Medico)}.{nameof(Medico.Usuario)}")
                                 .Include(_ => _.Receita)
                                 .Include($"{nameof(Consulta.Receita)}.{nameof(Receita.Medicamentos)}.{nameof(ReceitaMedicamento.Medicamento)}")
                                 .Include(_ => _.Especialidade)
                                 .AsQueryable();

            if (comExames)
                dbset = dbset.Include(_ => _.Exames)
                             .Include($"{nameof(Consulta.Exames)}.{nameof(Exame.TipoDeExame)}")
                             .Include($"{nameof(Consulta.Exames)}.{nameof(Exame.StatusExame)}")
                             .Include($"{nameof(Consulta.Exames)}.{nameof(Exame.LaboratorioRealizouExame)}")
                             .Include($"{nameof(Consulta.Exames)}.{nameof(Exame.LaboratorioRealizouExame)}.{nameof(Laboratorio.Usuario)}")
                             .AsQueryable();

            if (comAtestados)
                dbset = dbset.Include(_ => _.Atestados)
                             .Include($"{nameof(Consulta.Atestados)}.{nameof(Atestado.TipoDeAtestado)}")
                             .AsQueryable();

            return dbset.FirstOrDefault(_ => _.Id == id);
        }

        public IList<Consulta> ObterTudoComFiltros(DateTime dataInicio, DateTime dataFim, string busca, IEnumerable<EStatusConsulta> status, Guid? medicoId = null)
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
                                     .Include($"{nameof(Consulta.Medico)}.{nameof(Medico.Usuario)}")
                                     .Include(_ => _.Receita)
                                     .Include($"{nameof(Consulta.Receita)}.{nameof(Receita.Medicamentos)}.{nameof(ReceitaMedicamento.Medicamento)}")
                                     .Where(_ => _.Data.Date >= dataInicio.Date && _.Data.Date <= dataFim.Date).ToList();

            if (!string.IsNullOrEmpty(busca))
                consultas = consultas.Where(_ => _.Medico.Usuario.Nome.ToLowerContains(busca)
                                                 || _.Paciente.Nome.ToLowerContains(busca)
                                                 || _.Paciente.Id.ToString().ToLowerStartsWith(busca)
                                                 || _.Id.ToString().ToLowerStartsWith(busca)).ToList();

            if (status != null && status.Any())
                consultas = consultas.Where(_ => status.Contains(_.StatusConsulta.Id)).ToList();

            if (medicoId.HasValue && medicoId != Guid.Empty)
                consultas = consultas.Where(_ => _.Medico.Id == medicoId || _.Medico.Usuario.Id == medicoId).ToList();

            return consultas;
        }

        public Consulta ObterPorCodigo(string codigo)
        {
            return Entidades.Include(_ => _.Paciente)
                            .Include(_ => _.StatusConsulta)
                            .Include(_ => _.Medico)
                            .Include(_ => _.Especialidade)
                            .Include($"{nameof(Consulta.Medico)}.{nameof(Medico.Usuario)}")
                            .Include(_ => _.Receita)
                            .Include($"{nameof(Consulta.Receita)}.{nameof(Receita.Medicamentos)}.{nameof(ReceitaMedicamento.Medicamento)}")
                            .ToList()
                            .FirstOrDefault(_ => _.Id.ToString().ToLowerStartsWith(codigo));
        }
    }
}
