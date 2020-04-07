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
            var consultas = Entidades.Include(_ => _.Paciente)
                                 .Include(_ => _.StatusConsulta)
                                 .Include(_ => _.Medico)
                                 .Include($"{nameof(Consulta.Medico)}.{nameof(Medico.Usuario)}")
                                 .Include(_ => _.Receita)
                                 .Include($"{nameof(Consulta.Receita)}.{nameof(Receita.Medicamentos)}.{nameof(ReceitaMedicamento.Medicamento)}")
                                 .Include($"{nameof(Consulta.Receita)}.{nameof(Receita.Medicamentos)}.{nameof(ReceitaMedicamento.Medicamento)}.{nameof(Medicamento.Fabricante)}")
                                 .Include(_ => _.Especialidade)
                                 .AsQueryable();

            if (comExames)
                consultas = consultas.Include(_ => _.Exames)
                             .Include($"{nameof(Consulta.Exames)}.{nameof(Exame.TipoDeExame)}")
                             .Include($"{nameof(Consulta.Exames)}.{nameof(Exame.StatusExame)}")
                             .Include($"{nameof(Consulta.Exames)}.{nameof(Exame.LaboratorioRealizouExame)}")
                             .Include($"{nameof(Consulta.Exames)}.{nameof(Exame.LaboratorioRealizouExame)}.{nameof(Laboratorio.Usuario)}")
                             .AsQueryable();

            if (comAtestados)
                consultas = consultas.Include(_ => _.Atestados)
                             .Include($"{nameof(Consulta.Atestados)}.{nameof(Atestado.TipoDeAtestado)}")
                             .AsQueryable();

            return consultas.FirstOrDefault(_ => _.Id == id);
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
                            .Include($"{nameof(Consulta.Receita)}.{nameof(Receita.Medicamentos)}.{nameof(ReceitaMedicamento.Medicamento)}.{nameof(Medicamento.Fabricante)}")
                            .ToList()
                            .FirstOrDefault(_ => _.Id.ToString().ToLowerStartsWith(codigo));
        }

        public IList<Tuple<string, int>> ObterTotalConsultasPorEspecialidade(DateTime dataInicio, DateTime dataFim)
        {
            return Entidades.Include(_ => _.Especialidade)
                            .Include(_ => _.StatusConsulta)
                            .Where(_ => _.Data.Date >= dataInicio.Date && _.Data.Date <= dataFim.Date)
                            .Where(_ => _.StatusConsulta.Id != EStatusConsulta.Cancelada)
                            .OrderBy(_ => _.Especialidade.Nome)
                            .ToLookup(_ => _.Especialidade.Nome)
                            .Select(_ => Tuple.Create(_.Key, _.Count()))
                            .ToList();
        }

        public IList<Tuple<string, int>> ObterTotalConsultasPorMes(DateTime dataInicio, DateTime dataFim)
        {
            return Entidades.Include(_ => _.StatusConsulta)
                            .Where(_ => _.Data.Date >= dataInicio.Date && _.Data.Date <= dataFim.Date)
                            .Where(_ => _.StatusConsulta.Id != EStatusConsulta.Cancelada)
                            .OrderBy(_ => _.Data.Month).ThenBy(_ => _.Data.Year)
                            .ToList()
                            .ToLookup(_ => _.Data.ToString("MMM-yyyy"))
                            .Select(_ => Tuple.Create(_.Key, _.Count()))
                            .ToList();
        }

        public IList<Tuple<string, int>> ObterTotalConsultasPorSexoPaciente(DateTime dataInicio, DateTime dataFim)
        {
            return Entidades.Include(_ => _.Paciente)
                            .Include(_ => _.StatusConsulta)
                            .Where(_ => _.Data.Date >= dataInicio.Date && _.Data.Date <= dataFim.Date)
                            .Where(_ => _.StatusConsulta.Id != EStatusConsulta.Cancelada)
                            .ToLookup(_ => _.Paciente.Sexo)
                            .Select(_ => Tuple.Create(_.Key, _.Count()))
                            .ToList();
        }

        public IList<Tuple<int, int>> ObterTotalConsultasPorIdadePaciente(DateTime dataInicio, DateTime dataFim)
        {
            return Entidades.Include(_ => _.Paciente)
                            .Include(_ => _.StatusConsulta)
                            .Where(_ => _.Data.Date >= dataInicio.Date && _.Data.Date <= dataFim.Date)
                            .Where(_ => _.StatusConsulta.Id != EStatusConsulta.Cancelada)
                            .OrderBy(_ => DateTime.Now.Year - _.Paciente.DataNascimento.Year)
                            .ToLookup(_ => DateTime.Now.Year - _.Paciente.DataNascimento.Year)
                            .Select(_ => Tuple.Create(_.Key, _.Count()))
                            .ToList();
        }
    }
}
