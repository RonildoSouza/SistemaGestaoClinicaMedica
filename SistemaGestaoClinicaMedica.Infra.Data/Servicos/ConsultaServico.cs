using Microsoft.EntityFrameworkCore;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using SistemaGestaoClinicaMedica.Infra.Data.Queries;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public override void Deletar(Guid id)
        {
            var consulta = Entidades.Find(id);

            if (consulta == null)
                return;

            var status = _statusConsultaServico.Obter(EStatusConsulta.Cancelada);
            consulta.StatusConsulta = status;

            ContextoBancoDados.SaveChanges();
        }

        public override Consulta Obter(Guid id)
        {
            var consulta = Entidades.Include(_ => _.Paciente)
                                    .Include(_ => _.StatusConsulta)
                                    .Include(_ => _.Medico)
                                    .Include(_ => _.Especialidade)
                                    .Include($"{nameof(Consulta.Medico)}.{nameof(Medico.Funcionario)}")
                                    .FirstOrDefault(_ => _.Id == id);

            return consulta;
        }

        public IList<Consulta> ObterTudo(DateTime dataInicio, DateTime dataFim, string busca, EStatusConsulta? status)
        {
            return _consultasQuery.ObterTudo(dataInicio, dataFim, busca, status);
        }
    }
}
