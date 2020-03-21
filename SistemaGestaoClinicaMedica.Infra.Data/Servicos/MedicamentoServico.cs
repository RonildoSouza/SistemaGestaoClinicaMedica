using Microsoft.EntityFrameworkCore;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using SistemaGestaoClinicaMedica.Infra.Data.Queries;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaGestaoClinicaMedica.Infra.Data.Servicos
{
    public sealed class MedicamentoServico : ServicoBase<Guid, Medicamento>, IMedicamentoServico
    {
        private readonly IMedicamentosQuery _medicamentosQuery;

        public MedicamentoServico(ContextoBancoDados contextoBancoDados, IMedicamentosQuery medicamentosQuery) : base(contextoBancoDados)
        {
            _medicamentosQuery = medicamentosQuery;
        }

        public override void Deletar(Guid id)
        {
            var medicamento = Entidades.Find(id);

            if (medicamento == null)
                return;

            medicamento.Ativo = false;
            ContextoBancoDados.SaveChanges();
        }

        public override Medicamento Obter(Guid id, bool asNoTracking = false)
        {
            var entidade = Entidades.Include(_ => _.Fabricante)
                                    .FirstOrDefault(_ => _.Id == id);
            return entidade;
        }

        public IList<Medicamento> ObterTudoComFiltros(string busca, bool ativo)
        {
            return _medicamentosQuery.ObterTudoComFiltros(busca, ativo);
        }
    }
}
