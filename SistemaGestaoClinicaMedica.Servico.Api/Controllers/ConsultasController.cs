using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
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

        [Authorize("Bearer", Roles = "Administrador, Recepcionista, Medico")]
        [HttpGet]
        public IActionResult Get(DateTime dataInicio, DateTime dataFim, string busca, string status, Guid? medicoId)
        {
            var saidaDTOs = _consultaServicoAplicacao.ObterTudo(dataInicio, dataFim, busca, status, medicoId);
            return Ok(saidaDTOs);
        }

        [Authorize("Bearer", Roles = "Administrador, Recepcionista, Medico")]
        [HttpGet, Route("{id}")]
        public IActionResult GetPorId(Guid id, bool comExames, bool comAtestados)
        {
            var saidaDTO = _consultaServicoAplicacao.Obter(id, comExames, comAtestados);
            return Ok(saidaDTO);
        }

        [Authorize("Bearer", Roles = "Administrador, Recepcionista, Medico")]
        [HttpGet, Route("por-codigo/{codigo}")]
        public IActionResult GetPorCodigo(string codigo)
        {
            var saidaDTO = _consultaServicoAplicacao.ObterPorCodigo(codigo);
            return Ok(saidaDTO);
        }

        [Authorize("Bearer", Roles = "Administrador, Medico")]
        [HttpGet, Route("total-consultas-por-especialidade/{dataInicio}/{dataFim}")]
        public IActionResult GetTotalConsultasPorEspecialidade(DateTime dataInicio, DateTime dataFim)
        {
            var saidaDTOs = _consultaServicoAplicacao.ObterTotalConsultasPorEspecialidade(dataInicio, dataFim);
            return Ok(saidaDTOs);
        }

        [Authorize("Bearer", Roles = "Administrador, Medico")]
        [HttpGet, Route("total-consultas-por-mes/{dataInicio}/{dataFim}")]
        public IActionResult GetTotalConsultasPorMes(DateTime dataInicio, DateTime dataFim)
        {
            var saidaDTOs = _consultaServicoAplicacao.ObterTotalConsultasPorMes(dataInicio, dataFim);
            return Ok(saidaDTOs);
        }

        [Authorize("Bearer", Roles = "Administrador, Medico")]
        [HttpGet, Route("total-consultas-por-sexo-paciente/{dataInicio}/{dataFim}")]
        public IActionResult GetTotalConsultasPorSexoPaciente(DateTime dataInicio, DateTime dataFim)
        {
            var saidaDTOs = _consultaServicoAplicacao.ObterTotalConsultasPorSexoPaciente(dataInicio, dataFim);
            return Ok(saidaDTOs);
        }

        [Authorize("Bearer", Roles = "Administrador, Medico")]
        [HttpGet, Route("total-consultas-por-idade-paciente/{dataInicio}/{dataFim}")]
        public IActionResult GetTotalConsultasPorIdadePaciente(DateTime dataInicio, DateTime dataFim)
        {
            var saidaDTOs = _consultaServicoAplicacao.ObterTotalConsultasPorIdadePaciente(dataInicio, dataFim);
            return Ok(saidaDTOs);
        }

        [Authorize("Bearer", Roles = "Administrador, Recepcionista, Medico")]
        [HttpDelete, Route("{id}")]
        public IActionResult Delete(Guid id)
        {
            _consultaServicoAplicacao.Deletar(id);
            return Ok();
        }

        [Authorize("Bearer", Roles = "Administrador, Recepcionista, Medico")]
        [HttpPost]
        public IActionResult Post([FromBody]ConsultaDTO entradaDTO)
        {
            var saidaDTO = _consultaServicoAplicacao.Salvar(entradaDTO);

            if (saidaDTO == null)
                return BadRequest();

            return Created($"/{saidaDTO.Id}", saidaDTO);
        }

        [Authorize("Bearer", Roles = "Administrador, Recepcionista, Medico")]
        [HttpPut, Route("{id}")]
        public IActionResult Put([FromRoute]Guid id, [FromBody]ConsultaDTO entradaDTO)
        {
            var saidaDTO = _consultaServicoAplicacao.Salvar(entradaDTO, id);

            if (saidaDTO == null)
                return BadRequest();

            return Created($"/{saidaDTO.Id}", saidaDTO);
        }

        [Authorize("Bearer", Roles = "Administrador, Recepcionista, Medico")]
        [HttpPut, Route("alterar-status/{id}")]
        public IActionResult Put([FromRoute]Guid id, [FromBody]StatusConsultaDTO statusConsulta)
        {
            _consultaServicoAplicacao.AlterarStatus(id, statusConsulta);
            return Ok();
        }
    }
}