using Microsoft.EntityFrameworkCore;

namespace SistemaGestaoClinicaMedica.Infra.Data.Queries
{
    public abstract class QueryBase<TEntidade> : IQueryBase<TEntidade> where TEntidade : class
    {
        protected DbSet<TEntidade> Entidades { get; }

        protected QueryBase(ContextoBancoDados contextoBancoDados)
        {
            Entidades = contextoBancoDados.Set<TEntidade>();
        }
    }
}
