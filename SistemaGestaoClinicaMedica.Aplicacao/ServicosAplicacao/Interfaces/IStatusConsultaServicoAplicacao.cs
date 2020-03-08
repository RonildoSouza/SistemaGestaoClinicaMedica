using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Consulta;
using SistemaGestaoClinicaMedica.Dominio.Entidades;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public interface IStatusConsultaServicoAplicacao : IServicoAplicacaoLeitura<StatusConsultaSaidaDTO, EStatusConsulta>
    {
    }
}
