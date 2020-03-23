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
                                .Include($"{nameof(Especialidade.Medicos)}.{nameof(MedicoEspecialidade.Medico)}.{nameof(Medico.Funcionario)}")
                                .Where(_ => _.Medicos.Any() && _.Medicos.All(_ => _.Medico.Funcionario.Ativo))
                                .OrderBy(_ => _.Nome)
                                .ToList();

            return especialidadesComMedicoAtivo;
        }

        public IList<Especialidade> ObterTudoComFiltros(bool comMedicos = false)
        {
            if (comMedicos)
                return Entidades.Include(_ => _.Medicos)
                                .Include($"{nameof(Especialidade.Medicos)}.{nameof(MedicoEspecialidade.Medico)}")
                                .Include($"{nameof(Especialidade.Medicos)}.{nameof(MedicoEspecialidade.Medico)}.{nameof(Medico.Funcionario)}")
                                .OrderBy(_ => _.Nome)
                                .ToList();

            return Entidades.ToList();
        }

        public IList<TimeSpan> ObterHorariosDisponiveis(Guid especialidadeId, DateTime dataDaConsulta, Guid? medicoId = null)
        {
            var medicos = Entidades.Include(_ => _.Medicos)
                                .Include($"{nameof(Especialidade.Medicos)}.{nameof(MedicoEspecialidade.Medico)}")
                                .Include($"{nameof(Especialidade.Medicos)}.{nameof(MedicoEspecialidade.Medico)}.{nameof(Medico.HorariosDeTrabalho)}")
                                .Where(_ => _.Id == especialidadeId)
                                .Where(_ => _.Medicos.All(_ => _.Medico.HorariosDeTrabalho.All(_ => _.DiaDaSemana == dataDaConsulta.DayOfWeek)))
                                .SelectMany(_ => _.Medicos);
            var consultas = _consultaServico.ObterTudoComFiltros(dataDaConsulta, dataDaConsulta.AddMinutes(1439), null, new[] { EStatusConsulta.Agendada }, medicoId);

            if (medicoId.HasValue && medicoId != Guid.Empty)
                medicos = medicos.Where(_ => _.MedicoId == medicoId.GetValueOrDefault());

            var horarios = medicos.SelectMany(_ => _.Medico.HorariosDeTrabalho);
            var horariosDisponiveis = HorariosDisponiveis(horarios).ToList();

            RemoveHorariosIndisponiveis(ref horariosDisponiveis, horarios, consultas);

            return horariosDisponiveis;
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
            var horariosUnicosInicioAlmoco = horarios.GroupBy(_ => _.InicioAlmoco).Select(_ => _.Key);
            var horariosUnicosFimAlmoco = horarios.GroupBy(_ => _.FimAlmoco).Select(_ => _.Key);

            foreach (var horarioDisp in horariosDisponiveis.GetRange(0, horariosDisponiveis.Count()))
            {
                if (consultas.Select(_ => _.Data.TimeOfDay).Contains(horarioDisp))
                {
                    horariosDisponiveis.Remove(horarioDisp);
                    continue;
                }

                if (!horarios.Select(_ => _.Inicio).Contains(horarioDisp)
                    && (horariosUnicosInicioAlmoco.Contains(horarioDisp) || horariosUnicosFimAlmoco.Contains(horarioDisp)))
                {
                    horariosDisponiveis.Remove(horarioDisp);
                }
            }
        }
    }
}
