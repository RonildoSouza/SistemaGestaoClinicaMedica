using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using SistemaGestaoClinicaMedica.Infra.Data.Queries;
using System;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Infra.Data.Servicos
{
    public sealed class ConsultaServico : ServicoBase<Guid, Consulta>, IConsultaServico
    {
        private readonly IConsultasQuery _consultasQuery;
        private readonly IStatusConsultaServico _statusConsultaServico;

        public ConsultaServico(
            ContextoBancoDados contextoBancoDados,
            IConsultasQuery consultasQuery,
            IStatusConsultaServico statusConsultaServico) : base(contextoBancoDados)
        {
            _consultasQuery = consultasQuery;
            _statusConsultaServico = statusConsultaServico;
        }

        public void AlterarStatus(Guid id, EStatusConsulta eStatusConsulta)
        {
            var consulta = Entidades.Find(id);
            var statusConsulta = _statusConsultaServico.Obter(eStatusConsulta);
            consulta.StatusConsulta = statusConsulta;

            ContextoBancoDados.SaveChanges();
        }

        public override void Deletar(Guid id)
        {
            var consulta = Entidades.Find(id);

            if (consulta == null)
                return;

            AlterarStatus(id, EStatusConsulta.Cancelada);
        }

        public Consulta ObterComFiltros(Guid id, bool comExames, bool comAtestados)
        {
            return _consultasQuery.ObterComFiltros(id, comExames, comAtestados);
        }

        public IList<Consulta> ObterTudoComFiltros(DateTime dataInicio, DateTime dataFim, string busca, IEnumerable<EStatusConsulta> status, Guid? medicoId = null)
        {
            return _consultasQuery.ObterTudoComFiltros(dataInicio, dataFim, busca, status, medicoId);
        }
    }
}
