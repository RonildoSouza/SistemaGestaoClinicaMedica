using SistemaGestaoClinicaMedica.Servico.Api.DTOS;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public interface IFuncionarioServicoAplicacao
    {
        LoginSaidaDTO Autorizar(LoginEntradaDTO loginEntradaDTO);
    }
}
