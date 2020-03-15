using SistemaGestaoClinicaMedica.Dominio.Entidades;

namespace SistemaGestaoClinicaMedica.Infra.Data.Queries
{
    public interface IFabricantesQuery : IQueryBase<Fabricante>
    {
        Fabricante Obter(string nome);
    }
}
