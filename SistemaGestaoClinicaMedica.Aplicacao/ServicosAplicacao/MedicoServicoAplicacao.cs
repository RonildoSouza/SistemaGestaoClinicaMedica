using AutoMapper;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using System;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public sealed class MedicoServicoAplicacao : ServicoAplicacaoLeitura<MedicoDTO, Guid, Medico>, IMedicoServicoAplicacao
    {
        private readonly IMedicoServico _medicoServico;

        public MedicoServicoAplicacao(IMapper mapper, IMedicoServico medicoServico) : base(mapper, medicoServico)
        {
            _medicoServico = medicoServico;
        }

        public IList<MedicoDTO> ObterTudoPorEspecialidade(Guid especialidadeId)
        {
            var entidades = _medicoServico.ObterTudoPorEspecialidade(especialidadeId);
            return _mapper.Map<List<MedicoDTO>>(entidades);
        }
    }
}
