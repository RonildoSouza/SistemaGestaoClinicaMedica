using Microsoft.EntityFrameworkCore;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaGestaoClinicaMedica.Infra.Data.Queries
{
    public class ExamesQuery : QueryBase<Exame>, IExamesQuery
    {
        public ExamesQuery(ContextoBancoDados contextoBancoDados) : base(contextoBancoDados)
        {
        }

        public Exame ObterPorCodigo(string codigo)
        {
            var exames = Entidades.Include(_ => _.TipoDeExame)
                                  .Include(_ => _.StatusExame)
                                  .Include(_ => _.LaboratorioRealizouExame)
                                  .Include(_ => _.Consulta)
                                  .Include($"{nameof(Exame.LaboratorioRealizouExame)}.{nameof(Laboratorio.Usuario)}")
                                  .ToList();

            return exames.SingleOrDefault(_ => _.Id.ToString().ToLowerStartsWith(codigo));
        }

        public IList<Exame> ObterTudoPorConsultaId(Guid consultaId)
        {
            return Entidades.Include(_ => _.TipoDeExame)
                            .Include(_ => _.StatusExame)
                            .Include(_ => _.LaboratorioRealizouExame)
                            .Include(_ => _.Consulta)
                            .Include($"{nameof(Exame.LaboratorioRealizouExame)}.{nameof(Laboratorio.Usuario)}")
                            .Where(_ => _.Consulta.Id == consultaId)
                            .ToList();
        }

        public IList<Exame> ObterTudoComFiltro(string busca)
        {
            var exames = Entidades.Include(_ => _.TipoDeExame)
                                  .Include(_ => _.StatusExame)
                                  .Include(_ => _.LaboratorioRealizouExame)
                                  .Include(_ => _.Consulta)
                                  .Include($"{nameof(Exame.LaboratorioRealizouExame)}.{nameof(Laboratorio.Usuario)}")
                                  .Include($"{nameof(Exame.Consulta)}.{nameof(Consulta.Paciente)}");

            if (string.IsNullOrEmpty(busca))
                return exames.OrderByDescending(_ => _.CriadoEm).Take(30).ToList();

            return exames.ToList()
                         .Where(_ => _.Id.ToString().ToLowerStartsWith(busca)
                                  || _.Consulta.Id.ToString().ToLowerStartsWith(busca)
                                  || _.Consulta.Paciente.Id.ToString().ToLowerStartsWith(busca))
                         .OrderByDescending(_ => _.CriadoEm)
                         .Take(30)
                         .ToList();
        }

        public IList<Tuple<string, int>> ObterTotalExames(DateTime dataInicio, DateTime dataFim)
        {
            return Entidades.Include(_ => _.TipoDeExame)
                            .Where(_ => _.CriadoEm.Date >= dataInicio.Date && _.CriadoEm.Date <= dataFim.Date)
                            .OrderBy(_ => _.TipoDeExame.Nome)
                            .GroupBy(_ => _.TipoDeExame.Nome)
                            .Select(_ => Tuple.Create(_.Key, _.Count()))
                            .ToList();
        }
    }
}
