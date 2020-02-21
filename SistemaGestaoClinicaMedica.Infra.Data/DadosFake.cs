using SistemaGestaoClinicaMedica.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaGestaoClinicaMedica.Infra.Data
{
    public static class DadosFake
    {
        private static readonly IList<Funcionario> _funcionarios = new List<Funcionario>();

        public static IList<Funcionario> Funcionarios()
        {
            if (_funcionarios.Any())
                return _funcionarios;

            _funcionarios.Add(new Administrador
            {
                Ativo = true,
                Id = Guid.NewGuid(),
                Nome = "ADMINISTRADOR",
                Email = $"administrador@email.com",
                Senha = "123",
                Telefone = "(31) 99999-8888",
                Cargo = Cargos().ElementAt(0)
            });

            for (int i = 0; i < 50; i++)
            {
                var cargo = Cargos().ElementAt(new Random().Next(1, 2));

                _funcionarios.Add(new Administrador
                {
                    Ativo = i % 2 == 0,
                    Id = Guid.NewGuid(),
                    Nome = $"{cargo.Nome} {i}".ToUpper(),
                    Email = $"{cargo.Id}{i}@email.com".ToLower(),
                    Senha = "123",
                    Telefone = "(31) 99999-8888",
                    Cargo = cargo
                });
            }

            return _funcionarios;
        }

        public static IEnumerable<Cargo> Cargos()
        {
            yield return new Cargo
            {
                Id = "Administrador",
                Nome = "Administrador"
            };
            yield return new Cargo
            {
                Id = "Recepcionista",
                Nome = "Recepcionista"
            };
            yield return new Cargo
            {
                Id = "Medico",
                Nome = "Médico"
            };
        }
    }
}
