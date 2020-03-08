using Microsoft.EntityFrameworkCore;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using System.Linq;

namespace SistemaGestaoClinicaMedica.Infra.Data.Servicos
{
    public class ServicoBase<TId, TEntidade> : IServicoBase<TId, TEntidade> where TEntidade : class, IEntidade<TId>
    {
        protected ContextoBancoDados ContextoBancoDados { get; }
        protected DbSet<TEntidade> Entidades { get; }

        protected ServicoBase(ContextoBancoDados contextoBancoDados)
        {
            ContextoBancoDados = contextoBancoDados;
            Entidades = contextoBancoDados.Set<TEntidade>();
        }

        public virtual TEntidade Obter(TId id)
        {
            return Entidades.Find(id);
        }

        public virtual IQueryable<TEntidade> ObterTudo()
        {
            return Entidades.AsQueryable();
        }

        public virtual TEntidade Salvar(TEntidade entidade)
        {
            if (entidade.Id.Equals(default(TId)))
                Entidades.Add(entidade);
            else
            {
                if (Entidades.Local.FirstOrDefault(_ => _.Id.Equals(entidade.Id)) != null)
                    ContextoBancoDados.Entry(entidade).State = EntityState.Detached;

                Entidades.Update(entidade);
            }

            ContextoBancoDados.SaveChanges();

            return Obter(entidade.Id);
        }

        public virtual void Deletar(TId id) { throw new System.NotImplementedException(); }
    }
}
