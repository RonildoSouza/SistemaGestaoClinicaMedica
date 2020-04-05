using Microsoft.EntityFrameworkCore;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaGestaoClinicaMedica.Infra.Data.Queries
{
    public class EspecialidadesQuery : QueryBase<Especialidade>, IEspecialidadesQuery
    {
        private readonly IConsultaServico _consultaServico;

        public EspecialidadesQuery(ContextoBancoDados contextoBancoDados, IConsultaServico consultaServico) : base(contextoBancoDados)
        {
            _consultaServico = consultaServico;
        }

        public IList<Especialidade> ObterDisponiveis()
        {
            var especialidadesComMedicoAtivo = Entidades.Include(_ => _.Medicos)
                                .Include($"{nameof(Especialidade.Medicos)}.{nameof(MedicoEspecialidade.Medico)}")
                                .Include($"{nameof(Especialidade.Medicos)}.{nameof(MedicoEspecialidade.Medico)}.{nameof(Medico.Usuario)}")
                                .Where(_ => _.Medicos.Any(_ => _.Ativo) && _.Medicos.All(_ => _.Medico.Usuario.Ativo))
                                .OrderBy(_ => _.Nome)
                                .ToList();

            return especialidadesComMedicoAtivo;
        }

        public IList<Especialidade> ObterTudoComFiltros(bool comMedicos = false)
        {
            if (comMedicos)
                return Entidades.Include(_ => _.Medicos)
                                .Include($"{nameof(Especialidade.Medicos)}.{nameof(MedicoEspecialidade.Medico)}")
                                .Include($"{nameof(Especialidade.Medicos)}.{nameof(MedicoEspecialidade.Medico)}.{nameof(Medico.Usuario)}")
                                .OrderBy(_ => _.Nome)
                                .ToList();

            return Entidades.ToList();
        }

        public IList<TimeSpan> ObterHorariosDisponiveis(Guid especialidadeId, DateTime dataDaConsulta, Guid? medicoId = null)
        {
            var medicos = Entidades.Include(_ => _.Medicos)
                                   .Include($"{nameof(Especialidade.Medicos)}.{nameof(MedicoEspecialidade.Medico)}")
                                   .Include($"{nameof(Especialidade.Medicos)}.{nameof(MedicoEspecialidade.Medico)}.{nameof(Medico.HorariosDeTrabalho)}")
                                   .Include($"{nameof(Especialidade.Medicos)}.{nameof(MedicoEspecialidade.Medico)}.{nameof(Medico.Usuario)}")
                                   .Where(_ => _.Id == especialidadeId)
                                   .Where(_ => _.Medicos.Any(_ => _.Medico.HorariosDeTrabalho.Any(_ => _.DiaDaSemana == dataDaConsulta.DayOfWeek)))
                                   .Where(_ => _.Medicos.Any(_ => _.Ativo) && _.Medicos.Any(_ => _.Medico.Usuario.Ativo))
                                   .SelectMany(_ => _.Medicos);
            var consultas = _consultaServico.ObterTudoComFiltros(dataDaConsulta, dataDaConsulta.AddMinutes(1439), null, new[] { EStatusConsulta.Agendada, EStatusConsulta.Reagendada }, medicoId);

            if (medicoId.HasValue && medicoId != Guid.Empty)
                medicos = medicos.Where(_ => _.MedicoId == medicoId.GetValueOrDefault() || _.Medico.Usuario.Id == medicoId.GetValueOrDefault());

            var horarios = medicos.SelectMany(_ => _.Medico.HorariosDeTrabalho)
                                  .Where(_ => _.DiaDaSemana == dataDaConsulta.DayOfWeek && _.Ativo);
            var horariosDisponiveis = HorariosDisponiveis(horarios).ToList();

            RemoveHorariosIndisponiveis(ref horariosDisponiveis, horarios, consultas);

            return horariosDisponiveis;
        }

        public IDictionary<DateTime, bool> ObterDatasComHorariosDisponiveis(Guid especialidadeId, DateTime dataInicio, DateTime dataFim, Guid? medicoId = null)
        {
            var dicionarioDatas = new Dictionary<DateTime, bool>();

            if (especialidadeId == Guid.Empty)
                return dicionarioDatas;

            while (dataInicio <= dataFim)
            {
                var horarios = ObterHorariosDisponiveis(especialidadeId, dataInicio, medicoId);
                dicionarioDatas.Add(dataInicio, horarios.Any());
                dataInicio = dataInicio.AddDays(1);
            }

            return dicionarioDatas;
        }

        private IEnumerable<TimeSpan> HorariosDisponiveis(IEnumerable<HorarioDeTrabalho> horarios)
        {
            if (!horarios.Any())
                yield break;

            var intervalo = TimeSpan.Parse("00:30:00");
            var menorHorarioInicio = horarios.Min(_ => _.Inicio);
            var maiorHorarioFim = horarios.Max(_ => _.Fim);

            while (menorHorarioInicio <= maiorHorarioFim)
            {
                yield return menorHorarioInicio;
                menorHorarioInicio += intervalo;
            }
        }

        private void RemoveHorariosIndisponiveis(ref List<TimeSpan> horariosDisponiveis, IEnumerable<HorarioDeTrabalho> horarios, IList<Consulta> consultas)
        {
            var horariosUnicosInicioIntervalo = horarios.GroupBy(_ => _.InicioIntervalo).Select(_ => _.Key);
            var horariosUnicosFimIntervalo = horarios.GroupBy(_ => _.FimIntervalo).Select(_ => _.Key);

            foreach (var horarioDisp in horariosDisponiveis.GetRange(0, horariosDisponiveis.Count()))
            {
                if (consultas.Select(_ => _.Data.TimeOfDay).Contains(horarioDisp))
                {
                    horariosDisponiveis.Remove(horarioDisp);
                    continue;
                }

                if (!horarios.Select(_ => _.Inicio).Contains(horarioDisp)
                    && (horariosUnicosInicioIntervalo.Contains(horarioDisp) || horariosUnicosFimIntervalo.Contains(horarioDisp)))
                {
                    horariosDisponiveis.Remove(horarioDisp);
                }
            }
        }
    }
}
