using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using SistemaGestaoClinicaMedica.Infra.Data.Queries;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaGestaoClinicaMedica.Infra.Data.Servicos
{
    public sealed class FabricanteServico : ServicoBase<Guid, Fabricante>, IFabricanteServico
    {
        private readonly IFabricantesQuery _fabricantesQuery;

        public FabricanteServico(ContextoBancoDados contextoBancoDados, IFabricantesQuery fabricantesQuery) : base(contextoBancoDados)
        {
            _fabricantesQuery = fabricantesQuery;
        }

        public Fabricante ObterPorNome(string nome)
        {
            return _fabricantesQuery.ObterPorNome(nome);
        }

        public IList<Fabricante> ObterTudoPorNome(string nome)
        {
            return _fabricantesQuery.ObterTudoPorNome(nome).ToList();
        }
    }
}
