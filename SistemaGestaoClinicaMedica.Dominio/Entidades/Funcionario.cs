using System;

namespace SistemaGestaoClinicaMedica.Dominio.Entidades
{
    public class Funcionario : IEntidade<Guid>, IEntidadeAuditada
    {
        public Funcionario() { }

        public Funcionario(Guid id, string nome, string email, string telefone, string senha, Cargo cargo, bool ativo)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Telefone = telefone;
            Senha = senha;
            Cargo = cargo;
            Ativo = ativo;
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Senha { get; set; }
        public Cargo Cargo { get; set; }
        public bool Ativo { get; set; }
        public DateTime CriadoEm { get; set; }
        public string CriadoPor { get; set; }
        public DateTime? AtualizadoEm { get; set; }
        public string AtualizadoPor { get; set; }
    }
}
