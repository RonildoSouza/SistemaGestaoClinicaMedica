using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using System;
using System.Linq;

namespace SistemaGestaoClinicaMedica.Infra.Data.Servicos
{
    public sealed class MedicamentoServico : ServicoBase<Guid, Medicamento>, IMedicamentoServico
    {
        public MedicamentoServico(ContextoBancoDados contextoBancoDados) : base(contextoBancoDados)
        {
        }

        public void Deletar(Guid id)
        {
            var medicamento = ContextoBancoDados.Medicamentos.Find(id);

            if (medicamento == null)
                return;

            medicamento.Ativo = false;
            ContextoBancoDados.SaveChanges();
        }

        public IQueryable<Medicamento> ObterTudo(string nome, bool ativo = true)
        {
            return ContextoBancoDados.MedicamentosQuery.ObterTudo(nome, ativo);
        }
    }
}
