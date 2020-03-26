using Microsoft.EntityFrameworkCore;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using SistemaGestaoClinicaMedica.Infra.Data.Queries;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaGestaoClinicaMedica.Infra.Data.Servicos
{
    public sealed class AtestadoServico : ServicoBase<Guid, Atestado>, IAtestadoServico
    {
        private readonly IAtestadosQuery _atestadosQuery;

        public AtestadoServico(ContextoBancoDados contextoBancoDados, IAtestadosQuery atestadosQuery) : base(contextoBancoDados)
        {
            _atestadosQuery = atestadosQuery;
        }

        public override void Deletar(Guid id)
        {
            var entidade = Obter(id);

            ContextoBancoDados.Remove(entidade);
            ContextoBancoDados.SaveChanges();
        }

        public override Atestado Obter(Guid id, bool asNoTracking = false)
        {
            return Entidades.Include(_ => _.TipoDeAtestado)
                            .Include(_ => _.Consulta)
                            .FirstOrDefault(_ => _.Id == id);
        }

        public IList<Atestado> ObterTudoPorConsultaId(Guid consultaId)
        {
            return _atestadosQuery.ObterTudoPorConsultaId(consultaId);
        }
    }
}
