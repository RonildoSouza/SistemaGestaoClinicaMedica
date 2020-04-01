using SistemaGestaoClinicaMedica.Aplicacao.DTO;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public class TiposDeAtestadosServico : ServicoBaseLeitura<TipoDeAtestadoDTO, string>, ITiposDeAtestadosServico
    {
        public TiposDeAtestadosServico(ApplicationState applicationState) : base(applicationState) { }
    }
}
