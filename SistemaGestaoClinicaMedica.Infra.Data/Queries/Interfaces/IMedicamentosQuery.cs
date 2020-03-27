using SistemaGestaoClinicaMedica.Dominio.Entidades;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Infra.Data.Queries
{
    public interface IMedicamentosQuery : IQueryBase<Medicamento>
    {
        IEnumerable<Medicamento> ObterTudoPorNome(string nome);
        IList<Medicamento> ObterTudoComFiltros(string busca, bool ativo);
    }
}
