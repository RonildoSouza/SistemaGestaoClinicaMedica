using AutoMapper;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public sealed class StatusExameServicoAplicacao : ServicoAplicacaoLeitura<StatusExameDTO, EStatusExame, StatusExame>, IStatusExameServicoAplicacao
    {
        public StatusExameServicoAplicacao(IMapper mapper, IStatusExameServico statusExameServico) : base(mapper, statusExameServico)
        {
        }
    }
}
