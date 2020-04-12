using SistemaGestaoClinicaMedica.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Dominio.Servicos
{
    public interface IMedicoServico : IServicoBase<Guid, Medico>
    {
        IList<Medico> ObterTudoPorEspecialidade(Guid especialidadeId);
        Medico ObterPorCRM(string crm);
        IDictionary<DateTime, bool> ObterHorariosDeTrabalhoAtivosIntervaloDeData(Guid medicoId, DateTime dataInicio, DateTime dataFim);
    }
}
