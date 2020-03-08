using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using SistemaGestaoClinicaMedica.Infra.Data.Queries;
using System;

namespace SistemaGestaoClinicaMedica.Infra.Data.Servicos
{
    public sealed class ExameServico : ServicoBase<Guid, Exame>, IExameServico
    {
        private readonly IExamesQuery _examesQuery;
        private readonly IStatusExameServico _statusExameServico;

        public ExameServico(ContextoBancoDados contextoBancoDados, IExamesQuery examesQuery, IStatusExameServico statusExameServico) : base(contextoBancoDados)
        {
            _examesQuery = examesQuery;
            _statusExameServico = statusExameServico;
        }

        public Exame Obter(string codigo)
        {
            return _examesQuery.Obter(codigo);
        }
    }
}
