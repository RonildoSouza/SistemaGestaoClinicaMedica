using SistemaGestaoClinicaMedica.Dominio.Entidades;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Infra.Data.Queries
{
    public interface IFuncionariosQuery : IQueryBase<Funcionario>
    {
        Funcionario Autorizar(string email, string senha);
        IList<Funcionario> ObterTudoComFiltros(bool ativo);
    }
}
