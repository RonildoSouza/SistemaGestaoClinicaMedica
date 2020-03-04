using Microsoft.EntityFrameworkCore;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using System.Linq;

namespace SistemaGestaoClinicaMedica.Infra.Data.Queries
{
    public class MedicamentosQuery : QueryBase, IMedicamentosQuery
    {
        public IQueryable<Medicamento> ObterTudo(string nome, bool ativo = true)
        {
            var medicamentos = ContextoBancoDados.Medicamentos.Include(_ => _.Fabricante)
                                                  .Where(_ => _.Ativo == ativo)
                                                  .OrderBy(_ => _.Nome)
                                                  .AsQueryable();

            if (!string.IsNullOrEmpty(nome))
                medicamentos = medicamentos.Where(_ => _.Nome.Contains(nome) || _.NomeFabrica.Contains(nome));

            return medicamentos;
        }
    }
}
