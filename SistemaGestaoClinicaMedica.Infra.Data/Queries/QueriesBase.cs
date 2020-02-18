namespace SistemaGestaoClinicaMedica.Infra.Data.Queries
{
    public abstract class QueriesBase : IQueriesBase
    {
        public ContextoBancoDados ContextoBancoDados { get; private set; }

        public void SetaContextoBD(ContextoBancoDados contextoBancoDados)
        {
            ContextoBancoDados = contextoBancoDados;
        }
    }
}
