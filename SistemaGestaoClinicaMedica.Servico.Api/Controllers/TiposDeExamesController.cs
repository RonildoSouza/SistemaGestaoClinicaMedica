using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao;

namespace SistemaGestaoClinicaMedica.Servico.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposDeExamesController : ControllerBase
    {
        private readonly ITipoDeExameServicoAplicacao _tipoDeExameServicoAplicacao;

        public TiposDeExamesController(ITipoDeExameServicoAplicacao tipoDeExameServicoAplicacao)
        {
            _tipoDeExameServicoAplicacao = tipoDeExameServicoAplicacao;
        }

        [Authorize("Bearer", Roles = "Administrador, Medico, Laboratorio")]
        [HttpGet]
        public IActionResult Get()
        {
            var saidaDTOs = _tipoDeExameServicoAplicacao.ObterTudo();
            return Ok(saidaDTOs);
        }
    }
}