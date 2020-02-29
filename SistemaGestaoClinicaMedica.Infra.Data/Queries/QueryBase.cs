namespace SistemaGestaoClinicaMedica.Infra.Data.Queries
{
    public abstract class QueryBase : IQueryBase
    {
        public ContextoBancoDados ContextoBancoDados { get; private set; }

        public void SetaContextoBD(ContextoBancoDados contextoBancoDados)
        {
            ContextoBancoDados = contextoBancoDados;
        }
    }
}
