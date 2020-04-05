using Microsoft.EntityFrameworkCore;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using SistemaGestaoClinicaMedica.Infra.Data.Queries;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaGestaoClinicaMedica.Infra.Data.Servicos
{
    public sealed class ExameServico : ServicoBase<Guid, Exame>, IExameServico
    {
        private readonly IExamesQuery _examesQuery;
        private readonly IStatusExameServico _statusExameServico;

        public ExameServico(ContextoBancoDados contextoBancoDados, IExamesQuery examesQuery, IStatusExameServico statusExameServico) : base(contextoBancoDados)
        {
            _examesQuery = examesQuery;
            _statusExameServico = statusExameServico;
        }

        public override Exame Obter(Guid id, bool asNoTracking = false)
        {
            return Entidades.Include(_ => _.TipoDeExame)
                            .Include(_ => _.StatusExame)
                            .Include(_ => _.LaboratorioRealizouExame)
                            .Include($"{nameof(Exame.LaboratorioRealizouExame)}.{nameof(Laboratorio.Usuario)}")
                            .Include(_ => _.Consulta)
                            .FirstOrDefault(_ => _.Id == id);
        }

        public override IQueryable<Exame> ObterTudo(bool asNoTracking = false)
        {
            return Entidades.Include(_ => _.TipoDeExame)
                            .Include(_ => _.StatusExame)
                            .Include(_ => _.LaboratorioRealizouExame)
                            .Include($"{nameof(Exame.LaboratorioRealizouExame)}.{nameof(Laboratorio.Usuario)}")
                            .Include(_ => _.Consulta)
                            .AsQueryable();
        }

        public Exame ObterPorCodigo(string codigo)
        {
            return _examesQuery.ObterPorCodigo(codigo);
        }

        public void AlterarStatus(Guid id, EStatusExame eStatusExame)
        {
            var exame = Entidades.Find(id);
            var statusExame = _statusExameServico.Obter(eStatusExame);
            exame.StatusExame = statusExame;

            ContextoBancoDados.SaveChanges();
        }

        public IList<Exame> ObterTudoPorConsultaId(Guid consultaId)
        {
            return _examesQuery.ObterTudoPorConsultaId(consultaId);
        }

        public IList<Exame> ObterTudoComFiltro(string busca, IEnumerable<EStatusExame> status, Guid? medicoId = null)
        {
            return _examesQuery.ObterTudoComFiltro(busca, status, medicoId);
        }

        public IList<Tuple<string, int>> ObterTotalExames(DateTime dataInicio, DateTime dataFim)
        {
            return _examesQuery.ObterTotalExames(dataInicio, dataFim);
        }
    }
}
