using SistemaGestaoClinicaMedica.Aplicacao.DTO.Login;

namespace SistemaGestaoClinicaMedica.Infra.CrossCutting.Config.Servicos.Autenticacao
{
    public interface IAutenticacaoServico
    {
        LoginSaidaDTO Autenticar(LoginEntradaAutenticacaoDTO login);
    }
}