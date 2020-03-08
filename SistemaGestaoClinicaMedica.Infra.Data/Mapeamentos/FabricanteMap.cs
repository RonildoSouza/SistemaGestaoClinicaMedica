using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using System;

namespace SistemaGestaoClinicaMedica.Infra.Data.Mapeamentos
{
    public class FabricanteMap : MapeamentoBase<Guid, Fabricante>
    {
        public override void Configure(EntityTypeBuilder<Fabricante> builder)
        {
            base.Configure(builder);

            builder.Property(_ => _.Nome).HasMaxLength(500).IsRequired();

            builder.HasIndex(_ => new { _.Nome }).IsUnique();
        }
    }
}
