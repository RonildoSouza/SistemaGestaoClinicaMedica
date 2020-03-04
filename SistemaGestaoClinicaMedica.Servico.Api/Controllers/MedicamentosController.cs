using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Medicamento;
using SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao;
using System;

namespace SistemaGestaoClinicaMedica.Servico.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicamentosController : ControllerBase
    {
        private readonly IMedicamentoServicoAplicacao _medicamentoServicoAplicacao;

        public MedicamentosController(IMedicamentoServicoAplicacao medicamentoServicoAplicacao)
        {
            _medicamentoServicoAplicacao = medicamentoServicoAplicacao;
        }

        [Authorize("Bearer", Roles = "Administrador")]
        [HttpGet]
        public IActionResult Get(string nome, bool ativo = true)
        {
            var dtos = _medicamentoServicoAplicacao.ObterTudo(nome, ativo);
            return Ok(dtos);
        }

        [Authorize("Bearer", Roles = "Administrador")]
        [HttpGet, Route("{id}")]
        public IActionResult GetPorId(Guid id)
        {
            var dto = _medicamentoServicoAplicacao.Obter(id);
            return Ok(dto);
        }

        [Authorize("Bearer", Roles = "Administrador")]
        [HttpDelete, Route("{id}")]
        public IActionResult Delete(Guid id)
        {
            _medicamentoServicoAplicacao.Deletar(id);
            return Ok();
        }

        [Authorize("Bearer", Roles = "Administrador")]
        [HttpPost]
        public IActionResult Post([FromBody]MedicamentoEntradaDTO medicamentoEntradaDTO)
        {
            var dto = _medicamentoServicoAplicacao.Salvar(medicamentoEntradaDTO);

            if (dto == null)
                return BadRequest();

            return Created($"/{dto.Id}", dto);
        }

        [Authorize("Bearer", Roles = "Administrador")]
        [HttpPut, Route("{id}")]
        public IActionResult Put([FromRoute]Guid id, [FromBody]MedicamentoEntradaDTO medicamentoEntradaDTO)
        {
            var dto = _medicamentoServicoAplicacao.Salvar(medicamentoEntradaDTO, id);

            if (dto == null)
                return BadRequest();

            return Created($"api/funcionarios/{dto.Id}", dto);
        }
    }
}