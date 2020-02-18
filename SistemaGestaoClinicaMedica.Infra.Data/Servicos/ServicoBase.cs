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

        /*public void Deletar(TId id)
        {
            var entidade = ContextoBancoDados.Set<TEntidade>().Find(id);
            DelecaoLogica(ref entidade);

            ContextoBancoDados.SaveChangesAsync();

            void DelecaoLogica(ref TEntidade entity)
            {
                try
                {
                    var propertyDel = typeof(TEntidade).GetProperty("Del", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

                    if (propertyDel == null)
                        return;

                    propertyDel.SetValue(entity, DateTime.Now);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex.InnerException);
                }
            }
        }*/

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
