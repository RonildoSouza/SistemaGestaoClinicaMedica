using AutoMapper;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using System;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public sealed class FabricanteServicoAplicacao : ServicoAplicacaoLeitura<FabricanteDTO, Guid, Fabricante>, IFabricanteServicoAplicacao
    {
        private readonly IFabricanteServico _fabricanteServico;

        public FabricanteServicoAplicacao(IMapper mapper, IFabricanteServico fabricanteServico) : base(mapper, fabricanteServico)
        {
            _fabricanteServico = fabricanteServico;
        }

        public FabricanteDTO Obter(string nome)
        {
            var entidade = _fabricanteServico.ObterPorNome(nome);
            return _mapper.Map<FabricanteDTO>(entidade);
        }

        public IList<FabricanteDTO> ObterTudoPorNome(string nome)
        {
            var entidades = _fabricanteServico.ObterTudoPorNome(nome);
            return _mapper.Map<List<FabricanteDTO>>(entidades);
        }
    }
}
