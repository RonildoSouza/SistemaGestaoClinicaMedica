using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using SistemaGestaoClinicaMedica.Infra.Data.Queries;
using System;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Infra.Data.Servicos
{
    public sealed class EspecialidadeServico : ServicoBase<Guid, Especialidade>, IEspecialidadeServico
    {
        private readonly IEspecialidadesQuery _especialidadesQuery;

        public EspecialidadeServico(ContextoBancoDados contextoBancoDados, IEspecialidadesQuery especialidadesQuery) : base(contextoBancoDados)
        {
            _especialidadesQuery = especialidadesQuery;
        }

        public IList<Especialidade> ObterDisponiveis()
        {
            return _especialidadesQuery.ObterDisponiveis();
        }

        public IList<TimeSpan> ObterHorariosDisponiveis(Guid especialidadeId, DateTime dataDaConsulta, Guid? medicoId = null)
        {
            return _especialidadesQuery.ObterHorariosDisponiveis(especialidadeId, dataDaConsulta, medicoId);
        }

        public IList<Especialidade> ObterTudoComFiltros(bool comMedicos)
        {
            return _especialidadesQuery.ObterTudoComFiltros(comMedicos);
        }

        public IDictionary<DateTime, bool> ObterDatasComHorariosDisponiveis(Guid especialidadeId, DateTime dataInicio, DateTime dataFim, Guid? medicoId = null)
        {
            return _especialidadesQuery.ObterDatasComHorariosDisponiveis(especialidadeId, dataInicio, dataFim, medicoId);
        }
    }
}
