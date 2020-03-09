using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao;

namespace SistemaGestaoClinicaMedica.Servico.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposDeAtestadosController : ControllerBase
    {
        private readonly ITipoDeAtestadoServicoAplicacao _tipoDeAtestadoServicoAplicacao;

        public TiposDeAtestadosController(ITipoDeAtestadoServicoAplicacao tipoDeAtestadoServicoAplicacao)
        {
            _tipoDeAtestadoServicoAplicacao = tipoDeAtestadoServicoAplicacao;
        }

        [Authorize("Bearer", Roles = "Administrador, Medico")]
        [HttpGet]
        public IActionResult Get()
        {
            var saidaDTOs = _tipoDeAtestadoServicoAplicacao.ObterTudo();
            return Ok(saidaDTOs);
        }
    }
}