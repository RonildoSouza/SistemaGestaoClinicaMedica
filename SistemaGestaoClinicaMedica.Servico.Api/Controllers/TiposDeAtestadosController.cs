using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao;
using SistemaGestaoClinicaMedica.Dominio.Extensions;

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

        [Authorize("Bearer", Roles = "Administrador, Medico")]
        [HttpGet, Route("{id}")]
        public IActionResult GetPorId(string id)
        {
            var saidaDTO = _tipoDeAtestadoServicoAplicacao.Obter(id.StringParaTipoDeAtestado());
            return Ok(saidaDTO);
        }
    }
}