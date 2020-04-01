using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using System;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public class TiposDeExamesServico : ServicoBaseLeitura<TipoDeExameDTO, Guid>, ITiposDeExamesServico
    {
        public TiposDeExamesServico(ApplicationState applicationState) : base(applicationState) { }
    }
}
