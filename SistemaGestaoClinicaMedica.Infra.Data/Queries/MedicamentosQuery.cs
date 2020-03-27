using Microsoft.EntityFrameworkCore;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace SistemaGestaoClinicaMedica.Infra.Data.Queries
{
    public class MedicamentosQuery : QueryBase<Medicamento>, IMedicamentosQuery
    {
        public MedicamentosQuery(ContextoBancoDados contextoBancoDados) : base(contextoBancoDados)
        {
        }

        public IEnumerable<Medicamento> ObterTudoPorNome(string nome)
        {
            return Entidades.ToList().Where(_ => _.Ativo && _.Nome.ToLowerContains(nome))
                            .Take(10).OrderBy(_ => _.Nome);
        }

        public IList<Medicamento> ObterTudoComFiltros(string busca, bool ativo = true)
        {
            var medicamentos = Entidades.Include(_ => _.Fabricante)
                                        .Where(_ => _.Ativo == ativo)
                                        .OrderBy(_ => _.Nome)
                                        .ToList();

            if (!string.IsNullOrEmpty(busca))
                medicamentos = medicamentos.Where(_ => _.Nome.ToLowerContains(busca)
                                                       || _.NomeFabrica.ToLowerContains(busca)
                                                       || _.Tarja.ToLowerContains(busca)
                                                       || _.Fabricante.Nome.ToLowerContains(busca)).ToList();

            return medicamentos;
        }
    }
}
