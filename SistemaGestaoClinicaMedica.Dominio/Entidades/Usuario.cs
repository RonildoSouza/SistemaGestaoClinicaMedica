using System;

namespace SistemaGestaoClinicaMedica.Dominio.Entidades
{
    public class Usuario : IEntidade<Guid>, IEntidadeAuditada
    {
        public static Guid SuperUsuarioId => Guid.Parse("7270550F-6B18-41E2-9814-7DE97B8D966A");
        public Usuario() { }

        public Usuario(Guid id, string nome, string email, string telefone, string senha, Cargo cargo, bool ativo)
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

        public bool ESuperUsuario() => Id == SuperUsuarioId;

        public static string SenhaAleatoria() =>  Guid.NewGuid().ToString("d").Substring(1, 7);
    }
}
