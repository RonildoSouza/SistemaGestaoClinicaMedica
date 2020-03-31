using Blazored.LocalStorage;
using Microsoft.Extensions.Configuration;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public class CargosServico : ServicoBaseLeitura<CargoDTO, string>, ICargosServico
    {
        public CargosServico(IConfiguration configuration, ILocalStorageService localStorage) : base(configuration, localStorage) { }
    }
}
