using AutoMapper;
using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Medicamento;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using System;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public class FabricanteServicoAplicacao : ServicoAplicacaoLeitura<Fabricante, FabricanteSaidaDTO, Guid>, IFabricanteServicoAplicacao
    {
        private readonly IFabricanteServico _fabricanteServico;

        public FabricanteServicoAplicacao(IMapper mapper, IFabricanteServico fabricanteServico) : base(mapper, fabricanteServico)
        {
            _fabricanteServico = fabricanteServico;
        }

        public IList<FabricanteSaidaDTO> ObterTudo(string nome)
        {
            var entidades = _fabricanteServico.ObterTudo(nome?.ToUpper());
            return _mapper.Map<List<FabricanteSaidaDTO>>(entidades);
        }
    }
}
