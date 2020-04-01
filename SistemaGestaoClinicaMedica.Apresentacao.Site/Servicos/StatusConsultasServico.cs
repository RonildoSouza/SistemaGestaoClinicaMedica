using SistemaGestaoClinicaMedica.Aplicacao.DTO;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public class StatusConsultasServico : ServicoBaseLeitura<StatusConsultaDTO, string>, IStatusConsultasServico
    {
        public StatusConsultasServico(ApplicationState applicationState) : base(applicationState) { }
    }
}
