﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Funcionario;
using SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao;
using System;

namespace SistemaGestaoClinicaMedica.Servico.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        private readonly IFuncionarioServicoAplicacao _funcionarioServicoAplicacao;

        public FuncionariosController(IFuncionarioServicoAplicacao funcionarioServicoAplicacao)
        {
            _funcionarioServicoAplicacao = funcionarioServicoAplicacao;
        }

        [Authorize("Bearer", Roles = "Administrador")]
        [HttpGet]
        public IActionResult Get(bool ativo = true)
        {
            var dtos = _funcionarioServicoAplicacao.ObterTudo(ativo);
            return Ok(dtos);
        }

        [Authorize("Bearer", Roles = "Administrador")]
        [HttpGet, Route("{id}")]
        public IActionResult GetPorId(Guid id)
        {
            var dto = _funcionarioServicoAplicacao.Obter(id);
            return Ok(dto);
        }

        [Authorize("Bearer", Roles = "Administrador")]
        [HttpDelete, Route("{id}")]
        public IActionResult Delete(Guid id)
        {
            _funcionarioServicoAplicacao.Deletar(id);
            return Ok();
        }

        [Authorize("Bearer", Roles = "Administrador")]
        [HttpPost]
        public IActionResult Post([FromBody]FuncionarioEntradaDTO funcionarioEntradaDTO)
        {
            var dto = _funcionarioServicoAplicacao.Salvar(funcionarioEntradaDTO);

            if (dto == null)
                return BadRequest();

            return Created($"/{dto.Id}", dto);
        }

        [Authorize("Bearer", Roles = "Administrador")]
        [HttpPut, Route("{id}")]
        public IActionResult Put([FromRoute]Guid id, [FromBody]FuncionarioEntradaDTO funcionarioEntradaDTO)
        {
            var dto = _funcionarioServicoAplicacao.Salvar(funcionarioEntradaDTO, id);

            if (dto == null)
                return BadRequest();

            return Ok(dto);
        }
    }
}