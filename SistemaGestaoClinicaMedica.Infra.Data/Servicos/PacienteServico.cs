using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using SistemaGestaoClinicaMedica.Infra.Data.Queries;
using System;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Infra.Data.Servicos
{
    public sealed class PacienteServico : ServicoBase<Guid, Paciente>, IPacienteServico
    {
        private readonly IPacientesQuery _pacientesQuery;

        public PacienteServico(ContextoBancoDados contextoBancoDados, IPacientesQuery pacientesQuery) : base(contextoBancoDados)
        {
            _pacientesQuery = pacientesQuery;
        }

        public override void Deletar(Guid id)
        {
            var paciente = Entidades.Find(id);

            if (paciente == null)
                return;

            paciente.Ativo = false;
            ContextoBancoDados.SaveChanges();
        }

        public Paciente ObterPorCodigo(string pacienteCodigo)
        {
            return _pacientesQuery.ObterPorCodigo(pacienteCodigo);
        }

        public IList<Paciente> ObterTudoComFiltros(string busca, bool ativo)
        {
            return _pacientesQuery.ObterTudoComFiltros(busca, ativo);
        }
    }
}
