using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using SistemaGestaoClinicaMedica.Infra.Data.Queries;
using System;
using System.Collections.Generic;

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

        public IList<Medicamento> ObterTudo(string busca, bool ativo)
        {
            return _medicamentosQuery.ObterTudo(busca, ativo);
        }
    }
}
