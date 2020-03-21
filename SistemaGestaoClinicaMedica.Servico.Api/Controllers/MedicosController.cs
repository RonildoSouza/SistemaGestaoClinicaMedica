using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao;
using System;

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
    }
}