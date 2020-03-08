using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using System;

namespace SistemaGestaoClinicaMedica.Infra.Data.Mapeamentos
{
    public class PacienteMap : MapeamentoBase<Guid, Paciente>
    {
        public override void Configure(EntityTypeBuilder<Paciente> builder)
        {
            base.Configure(builder);

            builder.Property(_ => _.Nome).HasMaxLength(500).IsRequired();
            builder.Property(_ => _.DataNascimento).IsRequired();
            builder.Property(_ => _.Telefone).HasMaxLength(20).IsRequired();
            builder.Property(_ => _.Bairro).HasMaxLength(500).IsRequired();
            builder.Property(_ => _.Cidade).HasMaxLength(500).IsRequired();
            builder.Property(_ => _.Estado).HasMaxLength(50).IsRequired();
            builder.Property(_ => _.Ativo).HasDefaultValue(true);
            builder.Property(_ => _.CriadoEm).HasDefaultValueSql("date('now')").ValueGeneratedOnAdd();
        }
    }
}
