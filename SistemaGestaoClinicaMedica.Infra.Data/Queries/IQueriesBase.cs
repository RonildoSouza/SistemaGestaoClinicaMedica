namespace SistemaGestaoClinicaMedica.Infra.Data.Queries
{
    public interface IQueriesBase
    {
        ContextoBancoDados ContextoBancoDados { get; }

        void SetaContextoBD(ContextoBancoDados contextoBancoDados);
    }
}
