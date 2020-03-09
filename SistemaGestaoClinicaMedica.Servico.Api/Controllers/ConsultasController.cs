using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Consulta;
using SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao;
using System;

namespace SistemaGestaoClinicaMedica.Servico.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultasController : ControllerBase
    {
        private readonly IConsultaServicoAplicacao _consultaServicoAplicacao;

        public ConsultasController(IConsultaServicoAplicacao consultaServicoAplicacao)
        {
            _consultaServicoAplicacao = consultaServicoAplicacao;
        }

        [Authorize("Bearer", Roles = "Administrador, Recepcionista")]
        [HttpGet]
        public IActionResult Get(DateTime dataInicio, DateTime dataFim, string busca, string status)
        {
            var saidaDTOs = _consultaServicoAplicacao.ObterTudo(dataInicio, dataFim, busca, status);
            return Ok(saidaDTOs);
        }

        [Authorize("Bearer", Roles = "Administrador, Recepcionista")]
        [HttpGet, Route("{id}")]
        public IActionResult GetPorId(Guid id, bool comExames, bool comAtestados)
        {
            var saidaDTO = _consultaServicoAplicacao.Obter(id, comExames, comAtestados);
            return Ok(saidaDTO);
        }

        [Authorize("Bearer", Roles = "Administrador, Recepcionista")]
        [HttpDelete, Route("{id}")]
        public IActionResult Delete(Guid id)
        {
            _consultaServicoAplicacao.Deletar(id);
            return Ok();
        }

        [Authorize("Bearer", Roles = "Administrador, Recepcionista")]
        [HttpPost]
        public IActionResult Post([FromBody]ConsultaEntradaDTO entradaDTO)
        {
            var saidaDTO = _consultaServicoAplicacao.Salvar(entradaDTO);

            if (saidaDTO == null)
                return BadRequest();

            return Created($"/{saidaDTO.Id}", saidaDTO);
        }

        [Authorize("Bearer", Roles = "Administrador, Recepcionista, Medico")]
        [HttpPut, Route("{id}")]
        public IActionResult Put([FromRoute]Guid id, [FromBody]ConsultaEntradaDTO entradaDTO)
        {
            var saidaDTO = _consultaServicoAplicacao.Salvar(entradaDTO, id);

            if (saidaDTO == null)
                return BadRequest();

            return Created($"/{saidaDTO.Id}", saidaDTO);
        }
    }
}