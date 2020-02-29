using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using System;
using System.Linq;

namespace SistemaGestaoClinicaMedica.Infra.Data.Servicos
{
    public sealed class EspecialidadeServico : ServicoBase<Guid, Especialidade>, IEspecialidadeServico
    {
        public EspecialidadeServico(ContextoBancoDados contextoBancoDados) : base(contextoBancoDados)
        {
        }

        public IQueryable<Especialidade> ObterTudo(bool comMedicos = false)
        {
            return ContextoBancoDados.EspecialidadesQuery.ObterTudo(comMedicos);
        }
    }
}
