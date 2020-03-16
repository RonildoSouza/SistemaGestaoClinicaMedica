using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using SistemaGestaoClinicaMedica.Dominio.Entidades;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public interface IStatusExameServicoAplicacao : IServicoAplicacaoLeitura<StatusExameDTO, EStatusExame>
    {
    }
}
