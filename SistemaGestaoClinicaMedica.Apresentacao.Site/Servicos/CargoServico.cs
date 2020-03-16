using Microsoft.Extensions.Configuration;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public class CargoServico : ServicoBaseLeitura<CargoDTO, string>, ICargoServico
    {
        protected override string EndPoint => "cargos";

        public CargoServico(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
