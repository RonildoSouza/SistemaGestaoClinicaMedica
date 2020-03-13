using Microsoft.EntityFrameworkCore;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using System;
using System.Linq;

namespace SistemaGestaoClinicaMedica.Infra.Data.Queries
{
    public class ReceitasQuery : QueryBase<Receita>, IReceitasQuery
    {
        public ReceitasQuery(ContextoBancoDados contextoBancoDados) : base(contextoBancoDados)
        {
        }

        public Receita ObterPorConsultaId(Guid id)
        {
            var receita = Entidades.Include(_ => _.Consulta)
                                   .Include(_ => _.Medicamentos)
                                   .Include($"{nameof(Receita.Medicamentos)}.{nameof(ReceitaMedicamento.Medicamento)}")
                                   .FirstOrDefault(_ => _.Consulta.Id == id);

            return receita;
        }
    }
}
