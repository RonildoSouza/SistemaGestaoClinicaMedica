using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao;

namespace SistemaGestaoClinicaMedica.Servico.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusExamesController : ControllerBase
    {
        private readonly IStatusExameServicoAplicacao _statusExameServicoAplicacao;

        public StatusExamesController(IStatusExameServicoAplicacao statusExameServicoAplicacao)
        {
            _statusExameServicoAplicacao = statusExameServicoAplicacao;
        }

        [Authorize("Bearer")]
        [HttpGet]
        public IActionResult Get()
        {
            var saidaDTOs = _statusExameServicoAplicacao.ObterTudo();
            return Ok(saidaDTOs);
        }
    }
}