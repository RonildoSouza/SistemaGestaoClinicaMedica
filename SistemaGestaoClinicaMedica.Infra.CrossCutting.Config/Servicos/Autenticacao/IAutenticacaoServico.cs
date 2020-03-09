using SistemaGestaoClinicaMedica.Servico.Api.Controllers;
using SistemaGestaoClinicaMedica.Servico.Api.DTOS;

namespace SistemaGestaoClinicaMedica.Infra.CrossCutting.Config.Servicos.Autenticacao
{
    public interface IAutenticacaoServico
    {
        LoginSaidaDTO Autenticar(LoginEntradaAutenticacaoDTO login);
    }
}