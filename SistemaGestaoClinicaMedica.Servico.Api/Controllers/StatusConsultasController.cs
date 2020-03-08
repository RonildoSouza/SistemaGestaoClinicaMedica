using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao;

namespace SistemaGestaoClinicaMedica.Servico.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusConsultasController : ControllerBase
    {
        private readonly IStatusConsultaServicoAplicacao _statusConsultaServicoAplicacao;

        public StatusConsultasController(IStatusConsultaServicoAplicacao statusConsultaServicoAplicacao)
        {
            _statusConsultaServicoAplicacao = statusConsultaServicoAplicacao;
        }

        [Authorize("Bearer")]
        [HttpGet]
        public IActionResult Get()
        {
            var saidaDTOs = _statusConsultaServicoAplicacao.ObterTudo();
            return Ok(saidaDTOs);
        }
    }
}