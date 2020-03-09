using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Atestado;
using SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao;
using System;

namespace SistemaGestaoClinicaMedica.Servico.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtestadosController : ControllerBase
    {
        private readonly IAtestadoServicoAplicacao _atestadoServicoAplicacao;

        public AtestadosController(IAtestadoServicoAplicacao atestadoServicoAplicacao)
        {
            _atestadoServicoAplicacao = atestadoServicoAplicacao;
        }

        [Authorize("Bearer", Roles = "Administrador, Medico")]
        [HttpGet]
        public IActionResult Get()
        {
            var saidaDTOs = _atestadoServicoAplicacao.ObterTudo();
            return Ok(saidaDTOs);
        }

        [Authorize("Bearer", Roles = "Administrador, Medico")]
        [HttpGet, Route("{id}")]
        public IActionResult GetPorId(Guid id)
        {
            var saidaDTO = _atestadoServicoAplicacao.Obter(id);
            return Ok(saidaDTO);
        }

        [Authorize("Bearer", Roles = "Administrador, Medico")]
        [HttpDelete, Route("{id}")]
        public IActionResult Delete(Guid id)
        {
            _atestadoServicoAplicacao.Deletar(id);
            return Ok();
        }

        [Authorize("Bearer", Roles = "Administrador, Medico")]
        [HttpPost]
        public IActionResult Post([FromBody]AtestadoEntradaDTO entradaDTO)
        {
            var saidaDTO = _atestadoServicoAplicacao.Salvar(entradaDTO);

            if (saidaDTO == null)
                return BadRequest();

            return Created($"/{saidaDTO.Id}", saidaDTO);
        }

        [Authorize("Bearer", Roles = "Administrador, Medico")]
        [HttpPut, Route("{id}")]
        public IActionResult Put([FromRoute]Guid id, [FromBody]AtestadoEntradaDTO entradaDTO)
        {
            var saidaDTO = _atestadoServicoAplicacao.Salvar(entradaDTO, id);

            if (saidaDTO == null)
                return BadRequest();

            return Created($"/{saidaDTO.Id}", saidaDTO);
        }
    }
}