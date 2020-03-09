using SistemaGestaoClinicaMedica.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Dominio.Servicos
{
    public interface IConsultaServico : IServicoBase<Guid, Consulta>
    {
        Consulta Obter(Guid id, bool comExames, bool comAtestados);
        IList<Consulta> ObterTudo(DateTime dataInicio, DateTime dataFim, string busca, EStatusConsulta? status);
    }
}
