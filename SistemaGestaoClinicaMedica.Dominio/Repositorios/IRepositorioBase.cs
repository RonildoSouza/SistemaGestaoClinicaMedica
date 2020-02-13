using SistemaGestaoClinicaMedica.Dominio.Entidades;

namespace SistemaGestaoClinicaMedica.Dominio.Repositorios
{
    public interface IRepositorioBase<TId, TEntidade> : IRepositorioSomenteLeituraBase<TId, TEntidade>
        where TEntidade : IEntidade<TId>
    {
        void Deletar(TId id);
        TEntidade Salvar(TEntidade entidade);
    }
}
