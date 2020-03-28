using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao;
using System;

namespace SistemaGestaoClinicaMedica.Servico.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecepcionistasController : ControllerBase
    {
        private readonly IRecepcionistaServicoAplicacao _recepcionistaServicoAplicacao;

        public RecepcionistasController(IRecepcionistaServicoAplicacao recepcionistaServicoAplicacao)
        {
            _recepcionistaServicoAplicacao = recepcionistaServicoAplicacao;
        }

        [Authorize("Bearer", Roles = "Administrador")]
        [HttpGet, Route("{id}")]
        public IActionResult GetPorId(Guid id)
        {
            var saidaDTO = _recepcionistaServicoAplicacao.Obter(id);
            return Ok(saidaDTO);
        }

        [Authorize("Bearer", Roles = "Administrador")]
        [HttpPost]
        public IActionResult Post([FromBody]RecepcionistaDTO entradaDTO)
        {
            var saidaDTO = _recepcionistaServicoAplicacao.Salvar(entradaDTO);

            if (saidaDTO == null)
                return BadRequest();

            return Created($"/{saidaDTO.Id}", saidaDTO);
        }

        [Authorize("Bearer", Roles = "Administrador")]
        [HttpPut, Route("{id}")]
        public IActionResult Put([FromRoute]Guid id, [FromBody]RecepcionistaDTO entradaDTO)
        {
            var saidaDTO = _recepcionistaServicoAplicacao.Salvar(entradaDTO, id);

            if (saidaDTO == null)
                return BadRequest();

            return Ok(saidaDTO);
        }
    }
}