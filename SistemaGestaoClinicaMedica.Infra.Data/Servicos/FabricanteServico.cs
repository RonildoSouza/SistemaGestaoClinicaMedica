using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using SistemaGestaoClinicaMedica.Infra.Data.Queries;
using System;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Infra.Data.Servicos
{
    public sealed class FabricanteServico : ServicoBase<Guid, Fabricante>, IFabricanteServico
    {
        private readonly IFabricantesQuery _fabricantesQuery;

        public FabricanteServico(ContextoBancoDados contextoBancoDados, IFabricantesQuery fabricantesQuery) : base(contextoBancoDados)
        {
            _fabricantesQuery = fabricantesQuery;
        }

        public IList<Fabricante> ObterTudo(string nome)
        {
            return _fabricantesQuery.ObterTudo(nome);
        }
    }
}
