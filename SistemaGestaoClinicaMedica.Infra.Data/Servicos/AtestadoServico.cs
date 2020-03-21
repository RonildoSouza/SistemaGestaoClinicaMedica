using Microsoft.EntityFrameworkCore;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using System;
using System.Linq;

namespace SistemaGestaoClinicaMedica.Infra.Data.Servicos
{
    public sealed class AtestadoServico : ServicoBase<Guid, Atestado>, IAtestadoServico
    {
        public AtestadoServico(ContextoBancoDados contextoBancoDados) : base(contextoBancoDados)
        {
        }

        public override void Deletar(Guid id)
        {
            var entidade = Obter(id);

            ContextoBancoDados.Remove(entidade);
            ContextoBancoDados.SaveChanges();
        }

        public override IQueryable<Atestado> ObterTudo(bool asNoTracking = false)
        {
            return Entidades.Include(_ => _.TipoDeAtestado)
                            .Include(_ => _.Consulta)
                            .AsQueryable();
        }
    }
}
