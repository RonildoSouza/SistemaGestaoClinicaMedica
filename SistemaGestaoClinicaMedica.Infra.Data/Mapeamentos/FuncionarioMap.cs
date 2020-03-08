using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using System;

namespace SistemaGestaoClinicaMedica.Infra.Data.Mapeamentos
{
    public class FuncionarioMap : MapeamentoBase<Guid, Funcionario>
    {
        public override void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            base.Configure(builder);

            builder.Property(_ => _.Ativo).HasDefaultValue(true);
            builder.Property(_ => _.Email).HasMaxLength(200).IsRequired();
            builder.Property(_ => _.Nome).HasMaxLength(500).IsRequired();
            builder.Property(_ => _.Senha).HasMaxLength(100).IsRequired();
            builder.Property(_ => _.Telefone).HasMaxLength(100);
            builder.Property(_ => _.CriadoEm).HasDefaultValueSql("date('now')").ValueGeneratedOnAdd();

            builder.HasIndex(_ => new { _.Email }).IsUnique();

            builder.HasOne(_ => _.Cargo);
        }
    }
}
