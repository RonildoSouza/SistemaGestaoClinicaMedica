using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using SistemaGestaoClinicaMedica.Infra.Data.Queries;
using System;

namespace SistemaGestaoClinicaMedica.Infra.Data.Servicos
{
    public sealed class ExameServico : ServicoBase<Guid, Exame>, IExameServico
    {
        private readonly IExamesQuery _examesQuery;

        public ExameServico(ContextoBancoDados contextoBancoDados, IExamesQuery examesQuery, IStatusExameServico statusExameServico) : base(contextoBancoDados)
        {
            _examesQuery = examesQuery;
        }

        public Exame ObterPorCodigo(string codigo)
        {
            return _examesQuery.ObterPorCodigo(codigo);
        }
    }
}
