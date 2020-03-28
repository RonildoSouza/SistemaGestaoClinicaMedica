using Microsoft.EntityFrameworkCore;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using SistemaGestaoClinicaMedica.Infra.Data.Queries;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaGestaoClinicaMedica.Infra.Data.Servicos
{
    public sealed class MedicoServico : ServicoBase<Guid, Medico>, IMedicoServico
    {
        private readonly IMedicosQuery _medicosQuery;

        public MedicoServico(ContextoBancoDados contextoBancoDados, IMedicosQuery medicosQuery) : base(contextoBancoDados)
        {
            _medicosQuery = medicosQuery;
        }

        public override Medico Obter(Guid id, bool asNoTracking = false)
        {
            if (asNoTracking)
                return Entidades.Include(_ => _.Usuario)
                                .Include($"{nameof(Medico.Usuario)}.{nameof(Usuario.Cargo)}")
                                .Include(_ => _.HorariosDeTrabalho)
                                .Include($"{nameof(Medico.Especialidades)}.{nameof(MedicoEspecialidade.Especialidade)}")
                                .AsNoTracking()
                                .SingleOrDefault(_ => _.Id == id || _.Usuario.Id == id);

            return Entidades.Include(_ => _.Usuario)
                            .Include($"{nameof(Medico.Usuario)}.{nameof(Usuario.Cargo)}")
                            .Include(_ => _.HorariosDeTrabalho)
                            .Include($"{nameof(Medico.Especialidades)}.{nameof(MedicoEspecialidade.Especialidade)}")
                            .SingleOrDefault(_ => _.Id == id || _.Usuario.Id == id);
        }

        public IList<Medico> ObterTudoPorEspecialidade(Guid especialidadeId)
        {
            return _medicosQuery.ObterTudoPorEspecialidade(especialidadeId);
        }
    }
}
