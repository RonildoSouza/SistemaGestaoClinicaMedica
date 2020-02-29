using AutoMapper;
using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Cargo;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using System.Collections.Generic;
using System.Linq;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public sealed class CargoServicoAplicacao : ICargoServicoAplicacao
    {
        private readonly IMapper _mapper;
        private readonly ICargoServico _cargoServico;

        public CargoServicoAplicacao(IMapper mapper, ICargoServico cargoServico)
        {
            _mapper = mapper;
            _cargoServico = cargoServico;
        }

        public IList<CargoSaidaDTO> ObterTudo()
        {
            var entidades = _cargoServico.ObterTudo().OrderBy(_ => _.Nome).ToList();
            return _mapper.Map<List<CargoSaidaDTO>>(entidades);
        }
    }
}
