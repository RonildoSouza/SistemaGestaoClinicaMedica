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
            var dtos = _especialidadeServicoAplicacao.ObterTudo(comMedicos);
            return Ok(dtos);
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