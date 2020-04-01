using SistemaGestaoClinicaMedica.Aplicacao.DTO;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public class CargosServico : ServicoBaseLeitura<CargoDTO, string>, ICargosServico
    {
        public CargosServico(ApplicationState applicationState) : base(applicationState) { }
    }
}
