using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Exame;
using SistemaGestaoClinicaMedica.Dominio.Entidades;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public interface IStatusExameServicoAplicacao : IServicoAplicacaoLeitura<StatusExameSaidaDTO, EStatusExame>
    {
    }
}
