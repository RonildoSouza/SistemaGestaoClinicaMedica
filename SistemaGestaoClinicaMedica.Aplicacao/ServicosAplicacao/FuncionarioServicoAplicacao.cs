using SistemaGestaoClinicaMedica.Dominio.Servicos;
using SistemaGestaoClinicaMedica.Servico.Api.DTOS;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public sealed class FuncionarioServicoAplicacao : IFuncionarioServicoAplicacao
    {
        private readonly IFuncionarioServico _funcionarioServico;

        public FuncionarioServicoAplicacao(IFuncionarioServico funcionarioServico)
        {
            _funcionarioServico = funcionarioServico;
        }

        public LoginSaidaDTO Autorizar(LoginEntradaDTO loginEntradaDTO)
        {
            var entidade = _funcionarioServico.Autorizar(loginEntradaDTO.Email, loginEntradaDTO.Senha);

            return new LoginSaidaDTO { Email = entidade.Email, Senha = entidade.Senha };
        }
    }
}
