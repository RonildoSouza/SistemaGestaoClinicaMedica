using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using System;

namespace SistemaGestaoClinicaMedica.Infra.Data.Servicos
{
    public sealed class MedicoEspecialidadeServico : ServicoBase<Guid, MedicoEspecialidade>, IMedicoEspecialidadeServico
    {
        public MedicoEspecialidadeServico(ContextoBancoDados contextoBancoDados) : base(contextoBancoDados)
        {
        }
    }
}
