using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao;

namespace SistemaGestaoClinicaMedica.Servico.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargosController : ControllerBase
    {
        private readonly ICargoServicoAplicacao _cargoServicoAplicacao;

        public CargosController(ICargoServicoAplicacao cargoServicoAplicacao)
        {
            _cargoServicoAplicacao = cargoServicoAplicacao;
        }

        [Authorize("Bearer", Roles = "Administrador")]
        [HttpGet]
        public IActionResult Get()
        {
            var dtos = _cargoServicoAplicacao.ObterTudo();
            return Ok(dtos);
        }
    }
}