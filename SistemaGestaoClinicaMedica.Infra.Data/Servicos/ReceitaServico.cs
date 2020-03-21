using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using SistemaGestaoClinicaMedica.Infra.Data.Queries;
using System;

namespace SistemaGestaoClinicaMedica.Infra.Data.Servicos
{
    public sealed class ReceitaServico : ServicoBase<Guid, Receita>, IReceitaServico
    {
        private readonly IReceitasQuery _receitasQuery;

        public ReceitaServico(ContextoBancoDados contextoBancoDados, IReceitasQuery receitasQuery) : base(contextoBancoDados)
        {
            _receitasQuery = receitasQuery;
        }

        public override void Deletar(Guid id)
        {
            var entidade = Obter(id);

            ContextoBancoDados.Remove(entidade);
            ContextoBancoDados.SaveChanges();
        }

        public Receita ObterPorConsultaId(Guid consultaId)
        {
            return _receitasQuery.ObterPorConsultaId(consultaId);
        }
    }
}
