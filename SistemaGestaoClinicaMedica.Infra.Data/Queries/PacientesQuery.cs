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

        public Paciente ObterPorCodigoOuCPF(string codigoOuCpf)
        {
            return Entidades.Where(_ => _.Ativo)
                            .ToList()
                            .FirstOrDefault(_ => _.CPF.Equals(codigoOuCpf) || _.Id.ToString().ToLowerStartsWith(codigoOuCpf));
        }

        public IList<Paciente> ObterTudoComFiltros(string busca, bool ativo)
        {
            var pacientes = Entidades.Where(_ => _.Ativo == ativo)
                                                  .OrderBy(_ => _.Nome)
                                                  .ToList();

            if (!string.IsNullOrEmpty(busca))
                pacientes = pacientes.Where(_ => _.Nome.ToLowerContains(busca) || _.CPF.Equals(busca) || _.Id.ToString().ToLowerStartsWith(busca)).ToList();

            return pacientes;
        }
    }
}
