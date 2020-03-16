using AutoMapper;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public sealed class CargoServicoAplicacao : ServicoAplicacaoLeitura<CargoDTO, string, Cargo>, ICargoServicoAplicacao
    {
        public CargoServicoAplicacao(IMapper mapper, ICargoServico cargoServico) : base(mapper, cargoServico)
        {
        }
    }
}
