namespace SistemaGestaoClinicaMedica.Dominio.Entidades
{
    public interface IEntidade<TId>
    {
        TId Id { get; set; }
    }
}
