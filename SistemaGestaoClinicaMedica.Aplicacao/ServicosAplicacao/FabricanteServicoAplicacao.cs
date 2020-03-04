using AutoMapper;
using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Medicamento;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public class FabricanteServicoAplicacao : IFabricanteServicoAplicacao
    {
        private readonly IMapper _mapper;
        private readonly IFabricanteServico _fabricanteServico;

        public FabricanteServicoAplicacao(IMapper mapper, IFabricanteServico fabricanteServico)
        {
            _mapper = mapper;
            _fabricanteServico = fabricanteServico;
        }

        public IList<FabricanteSaidaDTO> ObterTudo(string nome)
        {
            var entidades = _fabricanteServico.ObterTudo(nome?.ToUpper());
            return _mapper.Map<List<FabricanteSaidaDTO>>(entidades);
        }
    }
}
