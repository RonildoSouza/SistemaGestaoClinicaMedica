using AutoMapper;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using System;

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
            var entidade = _fabricanteServico.Obter(nome);
            return _mapper.Map<FabricanteDTO>(entidade);
        }
    }
}
