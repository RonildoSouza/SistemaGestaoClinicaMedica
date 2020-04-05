using AutoMapper;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using SistemaGestaoClinicaMedica.Aplicacao.Interfaces.Email;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using SistemaGestaoClinicaMedica.Infra.CrossCutting.Config.Servicos;
using System;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public sealed class RecepcionistaServicoAplicacao : ServicoAplicacaoBase<RecepcionistaDTO, Guid, Recepcionista>, IRecepcionistaServicoAplicacao
    {
        private readonly IEmailSenhaNovoUsuarioServicoAplicacao _emailSenhaNovoUsuarioServicoAplicacao;

        public RecepcionistaServicoAplicacao(IMapper mapper, IRecepcionistaServico recepcionistaServico, IEmailSenhaNovoUsuarioServicoAplicacao emailSenhaNovoUsuarioServicoAplicacao) : base(mapper, recepcionistaServico)
        {
            _emailSenhaNovoUsuarioServicoAplicacao = emailSenhaNovoUsuarioServicoAplicacao;
        }

        public override RecepcionistaDTO Salvar(RecepcionistaDTO entradaDTO, Guid id = default)
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
