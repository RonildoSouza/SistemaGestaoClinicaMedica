using AutoMapper;
using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Receita;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using System;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public class ReceitaServicoAplicacao : ServicoAplicacaoBase<Receita, ReceitaSaidaDTO, ReceitaEntradaDTO, Guid>, IReceitaServicoAplicacao
    {
        private readonly IReceitaServico _receitaServico;

        public ReceitaServicoAplicacao(IMapper mapper, IReceitaServico receitaServico) : base(mapper, receitaServico)
        {
            _receitaServico = receitaServico;
        }

        public ReceitaSaidaDTO ObterPorConsultaId(Guid id)
        {
            var receita = _receitaServico.ObterPorConsultaId(id);
            return _mapper.Map<ReceitaSaidaDTO>(receita);
        }
    }
}
