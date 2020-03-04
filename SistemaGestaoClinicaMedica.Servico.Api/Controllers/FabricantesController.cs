using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao;

namespace SistemaGestaoClinicaMedica.Servico.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FabricantesController : ControllerBase
    {
        private readonly IFabricanteServicoAplicacao _fabricanteServicoAplicacao;

        public FabricantesController(IFabricanteServicoAplicacao fabricanteServicoAplicacao)
        {
            _fabricanteServicoAplicacao = fabricanteServicoAplicacao;
        }

        [Authorize("Bearer", Roles = "Administrador")]
        [HttpGet]
        public IActionResult Get(string nome)
        {
            var dtos = _fabricanteServicoAplicacao.ObterTudo(nome);
            return Ok(dtos);
        }
    }
}