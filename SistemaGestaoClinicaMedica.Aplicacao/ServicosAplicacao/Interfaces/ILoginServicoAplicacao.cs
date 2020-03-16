using SistemaGestaoClinicaMedica.Aplicacao.DTO.Login;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public interface ILoginServicoAplicacao
    {
        LoginEntradaAutenticacaoDTO Autorizar(LoginEntradaDTO loginEntradaDTO);
    }
}
