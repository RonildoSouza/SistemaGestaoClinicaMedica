using SistemaGestaoClinicaMedica.Dominio.Servicos;
using SistemaGestaoClinicaMedica.Servico.Api.DTOS;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public sealed class LoginServicoAplicacao : ILoginServicoAplicacao
    {
        private readonly IFuncionarioServico _funcionarioServico;

        public LoginServicoAplicacao(IFuncionarioServico funcionarioServico)
        {
            _funcionarioServico = funcionarioServico;
        }

        public LoginSaidaDTO Autorizar(LoginEntradaDTO loginEntradaDTO)
        {
            var entidade = _funcionarioServico.Autorizar(loginEntradaDTO.Email, loginEntradaDTO.Senha);

            if (entidade == null)
                return null;

            return new LoginSaidaDTO
            {
                Id = entidade.Id,
                Nome = entidade.Nome,
                CargoId = entidade.Cargo.Id,
                Email = entidade.Email
            };
        }
    }
}
