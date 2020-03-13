using Microsoft.Extensions.Configuration;
using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Cargo;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public class CargoServico : ServicoBaseLeitura<string, CargoSaidaDTO>, ICargoServico
    {
        protected override string EndPoint => "cargos";

        public CargoServico(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
