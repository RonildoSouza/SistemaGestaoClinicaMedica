namespace SistemaGestaoClinicaMedica.Infra.Data.Queries
{
    public interface IQueryBase
    {
        ContextoBancoDados ContextoBancoDados { get; }

        void SetaContextoBD(ContextoBancoDados contextoBancoDados);
    }
}
