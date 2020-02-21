using SistemaGestaoClinicaMedica.Dominio.Servicos;
using SistemaGestaoClinicaMedica.Servico.Api.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public sealed class FuncionarioServicoAplicacao : IFuncionarioServicoAplicacao
    {
        private readonly IFuncionarioServico _funcionarioServico;

        public FuncionarioServicoAplicacao(IFuncionarioServico funcionarioServico)
        {
            _funcionarioServico = funcionarioServico;
        }

        public LoginSaidaDTO Autorizar(LoginEntradaDTO loginEntradaDTO)
        {
            var entidade = _funcionarioServico.Autorizar(loginEntradaDTO.Email, loginEntradaDTO.Senha);

            if (entidade == null)
                return null;

            return new LoginSaidaDTO
            {
                Id = entidade.Id,
                Nome = entidade.Nome,
                CargoId = entidade.Cargo.Id,
                Email = entidade.Email
            };
        }

        public void Deletar(Guid id)
        {
            _funcionarioServico.Deletar(id);
        }

        public dynamic Obter(Guid id)
        {
            return _funcionarioServico.Obter(id);
        }

        public IList<dynamic> ObterTodos(bool ativo = true)
        {
            return _funcionarioServico.ObterTudoAtivoOuInativo(ativo).Cast<dynamic>().ToList();
        }
    }
}
