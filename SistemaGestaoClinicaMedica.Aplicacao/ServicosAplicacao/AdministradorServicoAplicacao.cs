using AutoMapper;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using SistemaGestaoClinicaMedica.Aplicacao.Interfaces.Email;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using SistemaGestaoClinicaMedica.Infra.CrossCutting.Config.Servicos;
using System;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public sealed class AdministradorServicoAplicacao : ServicoAplicacaoBase<AdministradorDTO, Guid, Administrador>, IAdministradorServicoAplicacao
    {
        private readonly IEmailSenhaNovoUsuarioServicoAplicacao _emailSenhaNovoUsuarioServicoAplicacao;

        public AdministradorServicoAplicacao(IMapper mapper, IAdministradorServico administradorServico, IEmailSenhaNovoUsuarioServicoAplicacao emailSenhaNovoUsuarioServicoAplicacao) : base(mapper, administradorServico)
        {
            _emailSenhaNovoUsuarioServicoAplicacao = emailSenhaNovoUsuarioServicoAplicacao;
        }

        public override AdministradorDTO Salvar(AdministradorDTO entradaDTO, Guid id = default)
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
