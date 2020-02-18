using SistemaGestaoClinicaMedica.Dominio.Entidades;
using System.Linq;

namespace SistemaGestaoClinicaMedica.Infra.Data.Queries
{
    public class FuncionarioQueries : QueriesBase, IFuncionarioQueries
    {
        public Funcionario Autorizar(string email, string senha)
        {
            return ContextoBancoDados.Funcionarios.FirstOrDefault(_ => _.Email == email && _.Senha == senha);
        }
    }
}
