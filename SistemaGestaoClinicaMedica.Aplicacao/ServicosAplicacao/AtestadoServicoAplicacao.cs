using AutoMapper;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using System;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public sealed class AtestadoServicoAplicacao : ServicoAplicacaoBase<AtestadoDTO, Guid, Atestado>, IAtestadoServicoAplicacao
    {
        private readonly IAtestadoServico _atestadoServico;

        public AtestadoServicoAplicacao(IMapper mapper, IAtestadoServico atestadoServico) : base(mapper, atestadoServico)
        {
            _atestadoServico = atestadoServico;
        }

        public IList<AtestadoDTO> ObterTudoPorConsultaId(Guid consultaId)
        {
            var entidades = _atestadoServico.ObterTudoPorConsultaId(consultaId);
            return _mapper.Map<List<AtestadoDTO>>(entidades);
        }
    }
}
