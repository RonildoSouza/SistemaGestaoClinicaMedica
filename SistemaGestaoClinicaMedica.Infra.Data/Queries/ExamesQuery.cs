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
                                  .Include($"{nameof(Exame.LaboratorioRealizouExame)}.{nameof(Laboratorio.Usuario)}")
                                  .Include(_ => _.Consulta)
                                  .ToList();

            return exames.SingleOrDefault(_ => _.Id.ToString().ToLowerStartsWith(codigo));
        }

        public IList<Exame> ObterTudoPorConsultaId(Guid consultaId)
        {
            return Entidades.Include(_ => _.TipoDeExame)
                            .Include(_ => _.StatusExame)
                            .Include(_ => _.LaboratorioRealizouExame)
                            .Include($"{nameof(Exame.LaboratorioRealizouExame)}.{nameof(Laboratorio.Usuario)}")
                            .Include(_ => _.Consulta)
                            .Where(_ => _.Consulta.Id == consultaId)
                            .ToList();
        }
    }
}
