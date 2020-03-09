using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using System;

namespace SistemaGestaoClinicaMedica.Infra.Data.Mapeamentos
{
    public class MedicamentoMap : MapeamentoBase<Guid, Medicamento>
    {
        public override void Configure(EntityTypeBuilder<Medicamento> builder)
        {
            base.Configure(builder);

            builder.Property(_ => _.Nome).HasMaxLength(100).IsRequired();
            builder.Property(_ => _.NomeFabrica).HasMaxLength(100).IsRequired();
            builder.Property(_ => _.Tarja).HasMaxLength(50).IsRequired();
            builder.Property(_ => _.Ativo).HasDefaultValue(true);

            builder.HasIndex(_ => new { _.Nome, _.NomeFabrica }).IsUnique();

            builder.HasOne(_ => _.Fabricante).WithMany().IsRequired();
        }
    }
}
