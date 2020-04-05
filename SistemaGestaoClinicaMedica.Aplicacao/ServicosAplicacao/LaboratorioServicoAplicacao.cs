using AutoMapper;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using SistemaGestaoClinicaMedica.Aplicacao.Interfaces.Email;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using SistemaGestaoClinicaMedica.Infra.CrossCutting.Config.Servicos;
using System;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public sealed class LaboratorioServicoAplicacao : ServicoAplicacaoBase<LaboratorioDTO, Guid, Laboratorio>, ILaboratorioServicoAplicacao
    {
        private readonly IEmailSenhaNovoUsuarioServicoAplicacao _emailSenhaNovoUsuarioServicoAplicacao;

        public LaboratorioServicoAplicacao(IMapper mapper, ILaboratorioServico laboratorioServico, IEmailSenhaNovoUsuarioServicoAplicacao emailSenhaNovoUsuarioServicoAplicacao) : base(mapper, laboratorioServico)
        {
            _emailSenhaNovoUsuarioServicoAplicacao = emailSenhaNovoUsuarioServicoAplicacao;
        }

        public override LaboratorioDTO Salvar(LaboratorioDTO entradaDTO, Guid id = default)
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
