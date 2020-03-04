using SistemaGestaoClinicaMedica.Dominio.Entidades;
using System.Linq;

namespace SistemaGestaoClinicaMedica.Dominio.Servicos
{
    public interface IServicoBase<TId, TEntidade> where TEntidade : IEntidade<TId>
    {
        TEntidade Obter(TId id);
        IQueryable<TEntidade> ObterTudo();
        TEntidade Salvar(TEntidade entidade);
        void Deletar(TId id);
    }
}
