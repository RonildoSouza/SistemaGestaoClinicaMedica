using AutoMapper;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using System;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public sealed class ReceitaServicoAplicacao : ServicoAplicacaoBase<ReceitaDTO, Guid, Receita>, IReceitaServicoAplicacao
    {
        private readonly IReceitaServico _receitaServico;

        public ReceitaServicoAplicacao(IMapper mapper, IReceitaServico receitaServico) : base(mapper, receitaServico)
        {
            _receitaServico = receitaServico;
        }

        public ReceitaDTO ObterPorConsultaId(Guid consultaId)
        {
            var receita = _receitaServico.ObterPorConsultaId(consultaId);
            return _mapper.Map<ReceitaDTO>(receita);
        }
    }
}
