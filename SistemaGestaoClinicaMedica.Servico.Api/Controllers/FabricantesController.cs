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
        [HttpGet("{nome}")]
        public IActionResult Get(string nome)
        {
            var saidaDTOs = _fabricanteServicoAplicacao.Obter(nome);
            return Ok(saidaDTOs);
        }

        [Authorize("Bearer", Roles = "Administrador")]
        [HttpGet, Route("por-nome/{nome}")]
        public IActionResult GetPorNome(string nome)
        {
            var saidaDTOs = _fabricanteServicoAplicacao.ObterTudoPorNome(nome);
            return Ok(saidaDTOs);
        }
    }
}