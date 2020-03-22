using SistemaGestaoClinicaMedica.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Dominio.Servicos
{
    public interface IConsultaServico : IServicoBase<Guid, Consulta>
    {
        Consulta ObterComFiltros(Guid id, bool comExames, bool comAtestados);
        IList<Consulta> ObterTudoComFiltros(DateTime dataInicio, DateTime dataFim, string busca, IEnumerable<EStatusConsulta> status);
    }
}
