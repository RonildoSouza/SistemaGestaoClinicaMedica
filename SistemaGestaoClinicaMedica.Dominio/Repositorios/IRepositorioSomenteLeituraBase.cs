using SistemaGestaoClinicaMedica.Dominio.Entidades;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Dominio.Repositorios
{
    public interface IRepositorioSomenteLeituraBase<TId, TEntidade>
        where TEntidade : IEntidade<TId>
    {
        TEntidade Obter(TId id);
        List<TEntidade> ObterTudo();
    }
}
