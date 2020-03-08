using AutoMapper;
using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Exame;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public sealed class StatusExameServicoAplicacao : ServicoAplicacaoLeitura<StatusExame, StatusExameSaidaDTO, EStatusExame>, IStatusExameServicoAplicacao
    {
        public StatusExameServicoAplicacao(IMapper mapper, IStatusExameServico statusExameServico) : base(mapper, statusExameServico)
        {
        }
    }
}
