using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao;
using System;

namespace SistemaGestaoClinicaMedica.Servico.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecialidadesController : ControllerBase
    {
        private readonly IEspecialidadeServicoAplicacao _especialidadeServicoAplicacao;

        public EspecialidadesController(IEspecialidadeServicoAplicacao especialidadeServicoAplicacao)
        {
            _especialidadeServicoAplicacao = especialidadeServicoAplicacao;
        }

        [Authorize("Bearer")]
        [HttpGet]
        public IActionResult Get(bool comMedicos = false)
        {
            var saidaDTOs = _especialidadeServicoAplicacao.ObterTudo(comMedicos);
            return Ok(saidaDTOs);
        }

        [Authorize("Bearer")]
        [HttpGet, Route("disponiveis")]
        public IActionResult Get()
        {
            var saidaDTOs = _especialidadeServicoAplicacao.ObterDisponiveis();
            return Ok(saidaDTOs);
        }

        [Authorize("Bearer")]
        [HttpGet, Route("{id}/horarios-disponiveis/{data}/{medicoId?}")]
        public IActionResult GetHorariosDisponiveis(Guid id, DateTime data, Guid? medicoId)
        {
            var saidaDTOs = _especialidadeServicoAplicacao.ObterHorariosDisponiveis(id, data, medicoId);
            return Ok(saidaDTOs);
        }        

        [Authorize("Bearer")]
        [HttpGet, Route("{id}")]
        public IActionResult GetPorId(Guid id)
        {
            var dto = _especialidadeServicoAplicacao.Obter(id);
            return Ok(dto);
        }
    }
}