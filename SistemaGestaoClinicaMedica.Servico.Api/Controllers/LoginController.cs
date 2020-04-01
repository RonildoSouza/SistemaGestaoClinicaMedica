using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaGestaoClinicaMedica.Aplicacao.DTO.Login;
using SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao;

namespace SistemaGestaoClinicaMedica.Servico.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginServicoAplicacao _loginServicoAplicacao;

        public LoginController(ILoginServicoAplicacao funcionarioServicoAplicacao)
        {
            _loginServicoAplicacao = funcionarioServicoAplicacao;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult PostAsync([FromBody] LoginEntradaDTO entradaDTO)
        {
            var loginSaida = _loginServicoAplicacao.Login(entradaDTO);

            if (loginSaida == null)
                return Unauthorized();

            return Ok(loginSaida);
        }
    }
}