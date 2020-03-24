using Microsoft.EntityFrameworkCore;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using SistemaGestaoClinicaMedica.Infra.Data.Queries;
using System;
using System.Linq;

namespace SistemaGestaoClinicaMedica.Infra.Data.Servicos
{
    public sealed class ExameServico : ServicoBase<Guid, Exame>, IExameServico
    {
        private readonly IExamesQuery _examesQuery;

        public ExameServico(ContextoBancoDados contextoBancoDados, IExamesQuery examesQuery, IStatusExameServico statusExameServico) : base(contextoBancoDados)
        {
            _examesQuery = examesQuery;
        }

        public override Exame Obter(Guid id, bool asNoTracking = false)
        {
            return Entidades.Include(_ => _.TipoDeExame)
                            .Include(_ => _.StatusExame)
                            .Include(_ => _.LaboratorioRealizouExame)
                            .Include($"{nameof(Exame.LaboratorioRealizouExame)}.{nameof(Laboratorio.Funcionario)}")
                            .FirstOrDefault(_ => _.Id == id);
        }

        public override IQueryable<Exame> ObterTudo(bool asNoTracking = false)
        {
            return Entidades.Include(_ => _.TipoDeExame)
                            .Include(_ => _.StatusExame)
                            .Include(_ => _.LaboratorioRealizouExame)
                            .Include($"{nameof(Exame.LaboratorioRealizouExame)}.{nameof(Laboratorio.Funcionario)}")
                            .AsQueryable();
        }

        public Exame ObterPorCodigo(string codigo)
        {
            return _examesQuery.ObterPorCodigo(codigo);
        }
    }
}
