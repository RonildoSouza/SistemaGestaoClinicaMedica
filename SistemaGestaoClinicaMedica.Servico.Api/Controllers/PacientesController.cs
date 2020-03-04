using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Paciente;
using SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao;
using System;

namespace SistemaGestaoClinicaMedica.Servico.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacientesController : ControllerBase
    {
        private readonly IPacienteServicoAplicacao _pacienteServicoAplicacao;

        public PacientesController(IPacienteServicoAplicacao pacienteServicoAplicacao)
        {
            _pacienteServicoAplicacao = pacienteServicoAplicacao;
        }

        [Authorize("Bearer")]
        [HttpGet]
        public IActionResult Get(string nome)
        {
            var saidaDTOs = _pacienteServicoAplicacao.ObterTudo(nome);
            return Ok(saidaDTOs);
        }

        [Authorize("Bearer")]
        [HttpGet, Route("{id}")]
        public IActionResult GetPorId(Guid id)
        {
            var saidaDTO = _pacienteServicoAplicacao.Obter(id);
            return Ok(saidaDTO);
        }

        //[Authorize("Bearer", Roles = "Administrador")]
        //[HttpDelete, Route("{id}")]
        //public IActionResult Delete(Guid id)
        //{
        //    _pacienteServicoAplicacao.Deletar(id);
        //    return Ok();
        //}

        [Authorize("Bearer", Roles = "Administrador, Recepcionista")]
        [HttpPost]
        public IActionResult Post([FromBody]PacienteEntradaDTO entradaDTO)
        {
            var saidaDTO = _pacienteServicoAplicacao.Salvar(entradaDTO);

            if (saidaDTO == null)
                return BadRequest();

            return Created($"/{saidaDTO.Id}", saidaDTO);
        }

        [Authorize("Bearer", Roles = "Administrador, Recepcionista")]
        [HttpPut, Route("{id}")]
        public IActionResult Put([FromRoute]Guid id, [FromBody]PacienteEntradaDTO medicamentoEntradaDTO)
        {
            var saidaDTO = _pacienteServicoAplicacao.Salvar(medicamentoEntradaDTO, id);

            if (saidaDTO == null)
                return BadRequest();

            return Created($"/{saidaDTO.Id}", saidaDTO);
        }
    }
}