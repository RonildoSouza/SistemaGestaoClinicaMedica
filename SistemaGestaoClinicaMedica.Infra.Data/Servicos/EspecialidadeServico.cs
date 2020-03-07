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

        public IList<Especialidade> ObterTudo(bool comMedicos)
        {
            return _especialidadesQuery.ObterTudo(comMedicos);
        }
    }
}
