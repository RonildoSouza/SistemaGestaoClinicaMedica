using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao;
using System;
using System.Web;

namespace SistemaGestaoClinicaMedica.Servico.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicosController : ControllerBase
    {
        private readonly IMedicoServicoAplicacao _medicoServicoAplicacao;

        public MedicosController(IMedicoServicoAplicacao medicoServicoAplicacao)
        {
            _medicoServicoAplicacao = medicoServicoAplicacao;
        }

        [Authorize("Bearer")]
        [HttpGet]
        public IActionResult Get()
        {
            var saidaDTOs = _medicoServicoAplicacao.ObterTudo();
            return Ok(saidaDTOs);
        }

        [Authorize("Bearer")]
        [HttpGet, Route("{id}")]
        public IActionResult GetPorId(Guid id)
        {
            var saidaDTO = _medicoServicoAplicacao.Obter(id);
            return Ok(saidaDTO);
        }

        [Authorize("Bearer")]
        [HttpGet, Route("por-especialidade/{especialidadeId}")]
        public IActionResult GetPorEspecialidade(Guid especialidadeId)
        {
            var saidaDTOs = _medicoServicoAplicacao.ObterTudoPorEspecialidade(especialidadeId);
            return Ok(saidaDTOs);
        }

        [Authorize("Bearer", Roles = "Administrador")]
        [HttpGet, Route("por-crm/{crm}")]
        public IActionResult GetPorCRM(string crm)
        {
            var saidaDTO = _medicoServicoAplicacao.ObterPorCRM(HttpUtility.UrlDecode(crm));
            return Ok(saidaDTO);
        }

        [Authorize("Bearer")]
        [HttpGet, Route("{id}/horarios-trabalho-ativos-intervalo-data/{dataInicio}/{dataFim}")]
        public IActionResult GetDatasComHorariosDisponiveis(Guid id, DateTime dataInicio, DateTime dataFim)
        {
            var saidaDTOs = _medicoServicoAplicacao.ObterHorariosDeTrabalhoAtivosIntervaloDeData(id, dataInicio, dataFim);
            return Ok(saidaDTOs);
        }

        [Authorize("Bearer", Roles = "Administrador")]
        [HttpPost]
        public IActionResult Post([FromBody]MedicoDTO entradaDTO)
        {
            var saidaDTO = _medicoServicoAplicacao.Salvar(entradaDTO);

            if (saidaDTO == null)
                return BadRequest();

            return Created($"/{saidaDTO.Id}", saidaDTO);
        }

        [Authorize("Bearer", Roles = "Administrador, Medico")]
        [HttpPut, Route("{id}")]
        public IActionResult Put([FromRoute]Guid id, [FromBody]MedicoDTO entradaDTO)
        {
            var saidaDTO = _medicoServicoAplicacao.Salvar(entradaDTO, id);

            if (saidaDTO == null)
                return BadRequest();

            return Ok(saidaDTO);
        }
    }
}