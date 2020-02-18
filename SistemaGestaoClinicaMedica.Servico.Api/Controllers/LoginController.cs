using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao;
using SistemaGestaoClinicaMedica.Infra.CrossCutting.Config.Servicos.Autenticacao;
using SistemaGestaoClinicaMedica.Servico.Api.DTOS;
using System;

namespace SistemaGestaoClinicaMedica.Servico.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IFuncionarioServicoAplicacao _funcionarioServicoAplicacao;
        private readonly IAutenticacaoServico _autenticacaoServico;

        public LoginController(IFuncionarioServicoAplicacao funcionarioServicoAplicacao, IAutenticacaoServico autenticacaoServico)
        {
            _funcionarioServicoAplicacao = funcionarioServicoAplicacao;
            _autenticacaoServico = autenticacaoServico;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult PostAsync([FromBody] LoginEntradaDTO loginEntradaDTO)
        {
            var autorizacao = _funcionarioServicoAplicacao.Autorizar(loginEntradaDTO);
            if (autorizacao == null)
                return Unauthorized();

            var autenticacao = _autenticacaoServico.Autenticar(new Dominio.Entidades.Administrador
            {
                Ativo = true,
                Id = Guid.NewGuid(),
                Nome = "Administrador",
                Email = "email@email.com",
                Senha = "123",
                Telefone = "(31) 99999-8888",
                Cargo = new Dominio.Entidades.Cargo
                {
                    Id = "Administrador",
                    Nome = "Administrador"
                }
            });

            if (autenticacao == null)
                return Unauthorized();

            return Ok(autenticacao);
        }
    }
}