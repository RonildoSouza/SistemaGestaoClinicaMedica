using AutoMapper;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using SistemaGestaoClinicaMedica.Servico.Api.DTOS;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public sealed class LoginServicoAplicacao : ILoginServicoAplicacao
    {
        private readonly IMapper _mapper;
        private readonly IFuncionarioServico _funcionarioServico;

        public LoginServicoAplicacao(IMapper mapper, IFuncionarioServico funcionarioServico)
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
