using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao;
using System;
using System.Linq;

namespace SistemaGestaoClinicaMedica.Servico.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamesController : ControllerBase
    {
        private readonly IExameServicoAplicacao _exameServicoAplicacao;

        public ExamesController(IExameServicoAplicacao exameServicoAplicacao)
        {
            _exameServicoAplicacao = exameServicoAplicacao;
        }

        [Authorize("Bearer", Roles = "Administrador")]
        [HttpGet]
        public IActionResult Get()
        {
            var saidaDTOs = _exameServicoAplicacao.ObterTudo();
            return Ok(saidaDTOs);
        }

        //[Authorize("Bearer")]
        //[HttpGet, Route("{id}")]
        //public IActionResult GetPorId(Guid id)
        //{
        //    var saidaDTO = _exameServicoAplicacao.Obter(id);
        //    return Ok(saidaDTO);
        //}

        [Authorize("Bearer")]
        [HttpGet, Route("{codigo}")]
        public IActionResult GetPorCodigo(string codigo)
        {
            var saidaDTO = _exameServicoAplicacao.Obter(codigo);
            return Ok(saidaDTO);
        }

        [Authorize("Bearer", Roles = "Administrador, Medico")]
        [HttpPost]
        public IActionResult Post([FromBody]ExameDTO entradaDTO)
        {
            var saidaDTO = _exameServicoAplicacao.Salvar(entradaDTO);

            if (saidaDTO == null)
                return BadRequest();

            return Created($"/{saidaDTO.Id}", saidaDTO);
        }

        [Authorize("Bearer", Roles = "Administrador, Medico, Laboratorio")]
        [HttpPut, Route("{id}")]
        public IActionResult Put(Guid id, [FromBody]ExameDTO entradaDTO)
        {
            var saidaDTO = _exameServicoAplicacao.Salvar(entradaDTO, id);

            if (saidaDTO == null)
                return BadRequest();

            return Created($"/{saidaDTO.Id}", saidaDTO);
        }

        [Authorize("Bearer", Roles = "Administrador, Medico, Laboratorio")]
        [HttpPost("~/api/exames/uploadresultado/{id}")]
        public IActionResult UploadResultado(Guid id)
        {
            var files = Request.Form.Files;

            if (!files.Any())
                return BadRequest("Nenhum arquivo enviado para upload!");

            var entradaDTO = files.Select(_ => new ArquivoResultadoExameDTO(_.FileName, _.OpenReadStream())).First();
            _exameServicoAplicacao.UploadResultado(id, entradaDTO);

            return Ok();
        }
    }
}