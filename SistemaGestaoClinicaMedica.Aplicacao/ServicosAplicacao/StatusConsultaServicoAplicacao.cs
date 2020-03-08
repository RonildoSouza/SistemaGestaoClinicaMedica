using AutoMapper;
using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Consulta;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public sealed class StatusConsultaServicoAplicacao : ServicoAplicacaoLeitura<StatusConsulta, StatusConsultaSaidaDTO, EStatusConsulta>, IStatusConsultaServicoAplicacao
    {
        public StatusConsultaServicoAplicacao(IMapper mapper, IStatusConsultaServico statusConsultaServico) : base(mapper, statusConsultaServico)
        {
        }
    }
}
