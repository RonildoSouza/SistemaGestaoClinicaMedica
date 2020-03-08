using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using System;

namespace SistemaGestaoClinicaMedica.Infra.Data.Mapeamentos
{
    public class TipoDeExameMap : MapeamentoBase<Guid, TipoDeExame>
    {
        public override void Configure(EntityTypeBuilder<TipoDeExame> builder)
        {
            base.Configure(builder);

            builder.Property(_ => _.Nome).HasMaxLength(500);

            builder.HasIndex(_ => new { _.Id, _.Nome }).IsUnique();
        }
    }
}
