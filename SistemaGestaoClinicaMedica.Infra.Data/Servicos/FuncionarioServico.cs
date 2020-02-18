using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using System;

namespace SistemaGestaoClinicaMedica.Infra.Data.Servicos
{
    public sealed class FuncionarioServico : ServicoBase<Guid, Funcionario>, IFuncionarioServico
    {
        public FuncionarioServico(ContextoBancoDados contextoBancoDados) : base(contextoBancoDados)
        {
        }

        public Funcionario Autorizar(string email, string senha)
        {

            return new Administrador
            {
                Ativo = true,
                Id = Guid.NewGuid(),
                Nome = "Administrador",
                Email = "email@email.com",
                Senha = "123",
                Telefone = "(31) 99999-8888",
                Cargo = new Cargo
                {
                    Id = "Administrador",
                    Nome = "Administrador"
                }
            };
            //return ContextoBancoDados.FuncionarioQueries.Autorizar(email, senha);
        }
    }
}
