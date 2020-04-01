using SistemaGestaoClinicaMedica.Aplicacao.DTO.Login;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public interface ILoginServicoAplicacao
    {
        LoginSaidaDTO Login(LoginEntradaDTO loginEntradaDTO);
    }
}
