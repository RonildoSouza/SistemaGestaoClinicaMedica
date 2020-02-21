using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using System;

namespace SistemaGestaoClinicaMedica.Infra.Data.Servicos
{
    public sealed class MedicoServico : ServicoBase<Guid, Medico>, IMedicoServico
    {
        public MedicoServico(ContextoBancoDados contextoBancoDados) : base(contextoBancoDados)
        {
        }
    }
}
