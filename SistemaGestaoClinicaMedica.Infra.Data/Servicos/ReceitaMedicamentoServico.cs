using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using System;

namespace SistemaGestaoClinicaMedica.Infra.Data.Servicos
{
    public sealed class ReceitaMedicamentoServico : ServicoBase<Guid, ReceitaMedicamento>, IReceitaMedicamentoServico
    {
        public ReceitaMedicamentoServico(ContextoBancoDados contextoBancoDados) : base(contextoBancoDados)
        {
        }

        public override void Deletar(Guid id)
        {
            var entidade = Entidades.Find(id);

            ContextoBancoDados.Remove(entidade);
            ContextoBancoDados.SaveChanges();
        }
    }
}
