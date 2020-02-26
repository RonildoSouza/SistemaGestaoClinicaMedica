using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using System;

namespace SistemaGestaoClinicaMedica.Infra.Data.Servicos
{
    public sealed class MedicoServico : ServicoBase<Guid, Medico>, IMedicoServico
    {
        private readonly IFuncionarioServico _funcionarioServico;

        public MedicoServico(ContextoBancoDados contextoBancoDados, IFuncionarioServico funcionarioServico) : base(contextoBancoDados)
        {
            _funcionarioServico = funcionarioServico;
        }

        //public override void Salvar(Medico entidade)
        //{
        //    var funcionario = _funcionarioServico.SalvarRetornaId(entidade.Funcionario);

        //    base.Salvar(entidade);
        //}
    }
}
