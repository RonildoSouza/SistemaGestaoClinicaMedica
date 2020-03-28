using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao;
using System;

namespace SistemaGestaoClinicaMedica.Servico.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LaboratoriosController : ControllerBase
    {
        private readonly ILaboratorioServicoAplicacao _laboratorioServicoAplicacao;

        public LaboratoriosController(ILaboratorioServicoAplicacao laboratorioServicoAplicacao)
        {
            _laboratorioServicoAplicacao = laboratorioServicoAplicacao;
        }

        [Authorize("Bearer", Roles = "Administrador")]
        [HttpGet, Route("{id}")]
        public IActionResult GetPorId(Guid id)
        {
            var saidaDTO = _laboratorioServicoAplicacao.Obter(id);
            return Ok(saidaDTO);
        }

        [Authorize("Bearer", Roles = "Administrador")]
        [HttpPost]
        public IActionResult Post([FromBody]LaboratorioDTO entradaDTO)
        {
            var saidaDTO = _laboratorioServicoAplicacao.Salvar(entradaDTO);

            if (saidaDTO == null)
                return BadRequest();

            return Created($"/{saidaDTO.Id}", saidaDTO);
        }

        [Authorize("Bearer", Roles = "Administrador")]
        [HttpPut, Route("{id}")]
        public IActionResult Put([FromRoute]Guid id, [FromBody]LaboratorioDTO entradaDTO)
        {
            var saidaDTO = _laboratorioServicoAplicacao.Salvar(entradaDTO, id);

            if (saidaDTO == null)
                return BadRequest();

            return Ok(saidaDTO);
        }
    }
}