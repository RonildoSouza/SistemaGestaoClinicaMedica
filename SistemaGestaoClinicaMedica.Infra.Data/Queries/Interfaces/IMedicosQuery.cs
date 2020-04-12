using SistemaGestaoClinicaMedica.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Infra.Data.Queries
{
    public interface IMedicosQuery : IQueryBase<Medico>
    {
        IList<Medico> ObterTudoPorEspecialidade(Guid especialidadeId);
        Medico ObterPorCRM(string crm);
        IDictionary<DateTime, bool> ObterHorariosDeTrabalhoAtivosIntervaloDeData(Guid medicoId, DateTime dataInicio, DateTime dataFim);
    }
}
