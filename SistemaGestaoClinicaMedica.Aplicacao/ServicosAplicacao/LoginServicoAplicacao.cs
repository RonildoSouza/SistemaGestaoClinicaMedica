using AutoMapper;
using SistemaGestaoClinicaMedica.Aplicacao.DTO.Login;
using SistemaGestaoClinicaMedica.Dominio.Servicos;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public sealed class LoginServicoAplicacao : ILoginServicoAplicacao
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioServico _funcionarioServico;

        public LoginServicoAplicacao(IMapper mapper, IUsuarioServico funcionarioServico)
        {
            _mapper = mapper;
            _funcionarioServico = funcionarioServico;
        }

        public LoginEntradaAutenticacaoDTO Autorizar(LoginEntradaDTO loginEntradaDTO)
        {
            var entidade = _funcionarioServico.Autorizar(loginEntradaDTO.Email, loginEntradaDTO.Senha);

            if (entidade == null)
                return null;

            return _mapper.Map<LoginEntradaAutenticacaoDTO>(entidade);
        }
    }
}
