using AutoMapper;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using SistemaGestaoClinicaMedica.Aplicacao.Interfaces.Email;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using SistemaGestaoClinicaMedica.Infra.CrossCutting.Config.Servicos;
using System;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public sealed class MedicoServicoAplicacao : ServicoAplicacaoBase<MedicoDTO, Guid, Medico>, IMedicoServicoAplicacao
    {
        private readonly IMedicoServico _medicoServico;
        private readonly IEmailSenhaNovoUsuarioServicoAplicacao _emailSenhaNovoUsuarioServicoAplicacao;

        public MedicoServicoAplicacao(IMapper mapper, IMedicoServico medicoServico, IEmailSenhaNovoUsuarioServicoAplicacao emailSenhaNovoUsuarioServicoAplicacao) : base(mapper, medicoServico)
        {
            _medicoServico = medicoServico;
            _emailSenhaNovoUsuarioServicoAplicacao = emailSenhaNovoUsuarioServicoAplicacao;
        }

        public IList<MedicoDTO> ObterTudoPorEspecialidade(Guid especialidadeId)
        {
            var entidades = _medicoServico.ObterTudoPorEspecialidade(especialidadeId);
            return _mapper.Map<List<MedicoDTO>>(entidades);
        }

        public override MedicoDTO Salvar(MedicoDTO entradaDTO, Guid id = default)
        {
            var senhaAleatoria = Usuario.SenhaAleatoria();

            if (entradaDTO.Id == Guid.Empty)
                entradaDTO.Senha = Encryption64.Encrypt(senhaAleatoria);

            var dto = base.Salvar(entradaDTO, id);

            if (id == default && dto?.Id != Guid.Empty)
                _emailSenhaNovoUsuarioServicoAplicacao.Enviar(dto.Email, dto.Nome, senhaAleatoria);

            return dto;
        }
    }
}
