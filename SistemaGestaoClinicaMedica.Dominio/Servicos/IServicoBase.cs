using SistemaGestaoClinicaMedica.Dominio.Entidades;
using System.Linq;

namespace SistemaGestaoClinicaMedica.Dominio.Servicos
{
    public interface IServicoBase<TId, TEntidade> where TEntidade : IEntidade<TId>
    {
        TEntidade Obter(TId id, bool asNoTracking = false);
        IQueryable<TEntidade> ObterTudo(bool asNoTracking = false);
        TEntidade Salvar(TEntidade entidade);
        void Deletar(TId id);
    }
}
