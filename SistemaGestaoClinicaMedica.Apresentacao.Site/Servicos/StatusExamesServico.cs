using SistemaGestaoClinicaMedica.Aplicacao.DTO;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public class StatusExamesServico : ServicoBaseLeitura<StatusExameDTO, string>, IStatusExamesServico
    {
        public StatusExamesServico(ApplicationState applicationState) : base(applicationState) { }
    }
}
