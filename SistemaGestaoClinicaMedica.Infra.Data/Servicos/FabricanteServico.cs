using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using System;
using System.Linq;

namespace SistemaGestaoClinicaMedica.Infra.Data.Servicos
{
    public sealed class FabricanteServico : ServicoBase<Guid, Fabricante>, IFabricanteServico
    {
        public FabricanteServico(ContextoBancoDados contextoBancoDados) : base(contextoBancoDados)
        {
        }

        public IQueryable<Fabricante> ObterTudo(string nome)
        {
            return ContextoBancoDados.FabricantesQuery.ObterTudo(nome);
        }
    }
}
