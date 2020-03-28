using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using System;

namespace SistemaGestaoClinicaMedica.Infra.Data.Mapeamentos
{
    public class AtestadoMap : MapeamentoBase<Guid, Atestado>
    {
        public override void Configure(EntityTypeBuilder<Atestado> builder)
        {
            base.Configure(builder);

            builder.Property(_ => _.Observacao).HasMaxLength(5000);

            builder.HasOne(_ => _.TipoDeAtestado).WithMany().IsRequired();
        }
    }
}
