using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace SistemaGestaoClinicaMedica.Infra.Data.Queries
{
    public class PacientesQuery : QueryBase<Paciente>, IPacientesQuery
    {
        public PacientesQuery(ContextoBancoDados contextoBancoDados) : base(contextoBancoDados)
        {
        }

        public IList<Paciente> ObterTudo(string busca, bool ativo)
        {
            var pacientes = Entidades.Where(_ => _.Ativo == ativo)
                                                  .OrderBy(_ => _.Nome)
                                                  .ToList();

            if (!string.IsNullOrEmpty(busca))
                pacientes = pacientes.Where(_ => _.Nome.ToLowerContains(busca) || _.Id.ToString().ToLowerStartsWith(busca)).ToList();

            return pacientes;
        }
    }
}
