using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using System.Linq;

namespace SistemaGestaoClinicaMedica.Infra.Data.Servicos
{
    public class ServicoBase<TId, TEntidade> : IServicoBase<TId, TEntidade> where TEntidade : class, IEntidade<TId>
    {
        public ContextoBancoDados ContextoBancoDados { get; }

        public ServicoBase(ContextoBancoDados contextoBancoDados)
        {
            ContextoBancoDados = contextoBancoDados;
        }

        public virtual TEntidade Obter(TId id)
        {
            return ContextoBancoDados.Set<TEntidade>().Find(id);
        }

        public virtual IQueryable<TEntidade> ObterTudo()
        {
            return ContextoBancoDados.Set<TEntidade>().AsQueryable();
        }

        public virtual void Salvar(TEntidade entidade)
        {
            if (entidade.Id.Equals(default(TId)))
                ContextoBancoDados.Set<TEntidade>().Add(entidade);
            else
                ContextoBancoDados.Set<TEntidade>().Update(entidade);

            ContextoBancoDados.SaveChanges();
        }
    }
}
