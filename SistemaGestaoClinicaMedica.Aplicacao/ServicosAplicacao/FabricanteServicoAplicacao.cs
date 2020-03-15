using AutoMapper;
using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Medicamento;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using System;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public class FabricanteServicoAplicacao : ServicoAplicacaoLeitura<Fabricante, FabricanteSaidaDTO, Guid>, IFabricanteServicoAplicacao
    {
        private readonly IFabricanteServico _fabricanteServico;

        public FabricanteServicoAplicacao(IMapper mapper, IFabricanteServico fabricanteServico) : base(mapper, fabricanteServico)
        {
            _fabricanteServico = fabricanteServico;
        }

        public FabricanteSaidaDTO Obter(string nome)
        {
            var entidade = _fabricanteServico.Obter(nome);
            return _mapper.Map<FabricanteSaidaDTO>(entidade);
        }
    }
}
