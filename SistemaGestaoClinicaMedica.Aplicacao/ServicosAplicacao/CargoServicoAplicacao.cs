using AutoMapper;
using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Cargo;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public sealed class CargoServicoAplicacao : ServicoAplicacaoLeitura<Cargo, CargoSaidaDTO, string>, ICargoServicoAplicacao
    {
        public CargoServicoAplicacao(IMapper mapper, ICargoServico cargoServico) : base(mapper, cargoServico)
        {
        }
    }
}
