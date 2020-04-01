using AutoMapper;
using SistemaGestaoClinicaMedica.Aplicacao.DTO.Login;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using SistemaGestaoClinicaMedica.Infra.CrossCutting.Config.Servicos.Autenticacao;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public sealed class LoginServicoAplicacao : ILoginServicoAplicacao
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioServico _usuarioServico;
        private readonly IAutenticacaoServico _autenticacaoServico;

        public LoginServicoAplicacao(IMapper mapper, IUsuarioServico funcionarioServico, IAutenticacaoServico autenticacaoServico)
        {
            _mapper = mapper;
            _usuarioServico = funcionarioServico;
            _autenticacaoServico = autenticacaoServico;
        }

        public LoginSaidaDTO Login(LoginEntradaDTO loginEntradaDTO)
        {
            var usuario = _usuarioServico.Autorizar(loginEntradaDTO.Email, loginEntradaDTO.Senha);

            if (usuario == null)
                return null;

            var loginAutenticacao = _mapper.Map<LoginAutenticacaoDTO>(usuario);
            var loginSaida = _autenticacaoServico.Autenticar(loginAutenticacao);
            
            return loginSaida;
        }
    }
}
