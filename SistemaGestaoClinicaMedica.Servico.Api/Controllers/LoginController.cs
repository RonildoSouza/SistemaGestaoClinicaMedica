using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao;
using SistemaGestaoClinicaMedica.Infra.CrossCutting.Config.Modelos;
using SistemaGestaoClinicaMedica.Infra.CrossCutting.Config.Servicos.Autenticacao;
using SistemaGestaoClinicaMedica.Servico.Api.DTOS;

namespace SistemaGestaoClinicaMedica.Servico.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginServicoAplicacao _loginServicoAplicacao;
        private readonly IAutenticacaoServico _autenticacaoServico;

        public LoginController(ILoginServicoAplicacao funcionarioServicoAplicacao, IAutenticacaoServico autenticacaoServico)
        {
            _loginServicoAplicacao = funcionarioServicoAplicacao;
            _autenticacaoServico = autenticacaoServico;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult PostAsync([FromBody] LoginEntradaDTO loginEntradaDTO)
        {
            var autorizacao = _loginServicoAplicacao.Autorizar(loginEntradaDTO);
            if (autorizacao == null)
                return Unauthorized();

            var autenticacao = _autenticacaoServico.Autenticar(
                new AutenticacaoEntrada
                {
                    Id = autorizacao.Id,
                    Nome = autorizacao.Nome,
                    Email = autorizacao.Email,
                    CargoId = autorizacao.CargoId
                });

            if (autenticacao == null)
                return Unauthorized();

            return Ok(autenticacao);
        }
    }
}