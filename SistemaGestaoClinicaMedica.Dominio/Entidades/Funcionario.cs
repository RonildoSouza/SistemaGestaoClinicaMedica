using System;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Dominio.Entidades
{
    public class Funcionario : IEntidade<Guid>
    {
        public Funcionario() { }

        public Funcionario(string nome, string email, string telefone, string senha, Cargo cargo)
        {
            //Id = Guid.NewGuid();
            //CriadoEm = DateTime.Now;

            Nome = nome;
            Email = email;
            Telefone = telefone;
            Senha = senha;
            Cargo = cargo;
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Senha { get; set; }
        public Cargo Cargo { get; set; }
        public bool Ativo { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}
