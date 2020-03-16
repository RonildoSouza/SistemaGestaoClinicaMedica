using AutoMapper;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public sealed class StatusConsultaServicoAplicacao : ServicoAplicacaoLeitura<StatusConsultaDTO, EStatusConsulta, StatusConsulta>, IStatusConsultaServicoAplicacao
    {
        public StatusConsultaServicoAplicacao(IMapper mapper, IStatusConsultaServico statusConsultaServico) : base(mapper, statusConsultaServico)
        {
        }
    }
}
