using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using System;
using System.Linq;

namespace SistemaGestaoClinicaMedica.Infra.Data.Servicos
{
    public sealed class MedicoServico : ServicoBase<Guid, Medico>, IMedicoServico
    {
        public MedicoServico(ContextoBancoDados contextoBancoDados) : base(contextoBancoDados)
        {
        }

        public override Medico Obter(Guid id)
        {
            return Entidades.SingleOrDefault(_ => _.Id == id || _.Funcionario.Id == id);
        }
    }
}
