using Microsoft.AspNetCore.Authorization;
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
            var funcionarios = _funcionarioServicoAplicacao.ObterTodos(ativo);
            return Ok(funcionarios);
        }

        [Authorize("Bearer", Roles = "Administrador")]
        [HttpGet, Route("{id}")]
        public IActionResult GetPorId(Guid id)
        {
            var funcionario = _funcionarioServicoAplicacao.Obter(id);
            return Ok(funcionario);
        }

        [Authorize("Bearer", Roles = "Administrador")]
        [HttpDelete, Route("{id}")]
        public IActionResult Delete(Guid id)
        {
            _funcionarioServicoAplicacao.Deletar(id);
            return Ok(id);
        }

        [Authorize("Bearer", Roles = "Administrador")]
        [HttpPost, Route("{id}")]
        public IActionResult Post([FromBody]FuncionarioEntradaDTO funcionarioEntradaDTO)
        {
            _funcionarioServicoAplicacao.Salvar(funcionarioEntradaDTO);
            return Ok();
        }
    }
}