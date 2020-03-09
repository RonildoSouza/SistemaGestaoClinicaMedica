using SistemaGestaoClinicaMedica.Servico.Api.DTOS;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public interface ILoginServicoAplicacao
    {
        LoginEntradaAutenticacaoDTO Autorizar(LoginEntradaDTO loginEntradaDTO);
    }
}
