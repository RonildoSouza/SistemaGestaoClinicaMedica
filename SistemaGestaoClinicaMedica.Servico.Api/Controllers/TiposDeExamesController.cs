using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao;
using System;

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

        [Authorize("Bearer", Roles = "Administrador, Medico, Laboratorio")]
        [HttpGet, Route("{id}")]
        public IActionResult GetPorId(Guid id)
        {
            var saidaDTO = _tipoDeExameServicoAplicacao.Obter(id);
            return Ok(saidaDTO);
        }
    }
}