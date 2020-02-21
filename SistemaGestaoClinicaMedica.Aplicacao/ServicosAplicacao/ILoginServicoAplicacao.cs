using SistemaGestaoClinicaMedica.Servico.Api.DTOS;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public interface ILoginServicoAplicacao
    {
        LoginSaidaDTO Autorizar(LoginEntradaDTO loginEntradaDTO);
    }
}
