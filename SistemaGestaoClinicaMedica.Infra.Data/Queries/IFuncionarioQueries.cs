using SistemaGestaoClinicaMedica.Dominio.Entidades;

namespace SistemaGestaoClinicaMedica.Infra.Data.Queries
{
    public interface IFuncionarioQueries : IQueriesBase
    {
        Funcionario Autorizar(string email, string senha);
    }
}
