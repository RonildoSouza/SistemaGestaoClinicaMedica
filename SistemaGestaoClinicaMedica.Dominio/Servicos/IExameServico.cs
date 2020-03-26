using SistemaGestaoClinicaMedica.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Dominio.Servicos
{
    public interface IExameServico : IServicoBase<Guid, Exame>
    {
        Exame ObterPorCodigo(string codigo);
        void AlterarStatus(Guid id, EStatusExame eStatusExame);
        IList<Exame> ObterTudoPorConsultaId(Guid consultaId);
    }
}
