using Microsoft.Extensions.Configuration;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public class TiposDeAtestadosServico : ServicoBaseLeitura<TipoDeAtestadoDTO, string>, ITiposDeAtestadosServico
    {
        public TiposDeAtestadosServico(IConfiguration configuration) : base(configuration) { }
    }
}
