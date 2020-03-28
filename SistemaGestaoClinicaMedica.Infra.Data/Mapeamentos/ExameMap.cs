using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using System;

namespace SistemaGestaoClinicaMedica.Infra.Data.Mapeamentos
{
    public class ExameMap : MapeamentoBase<Guid, Exame>
    {
        public override void Configure(EntityTypeBuilder<Exame> builder)
        {
            base.Configure(builder);

            builder.Property(_ => _.Observacao).HasMaxLength(5000);
            builder.Property(_ => _.LinkResultadoExame).HasMaxLength(500);

            builder.HasOne(_ => _.TipoDeExame).WithMany().IsRequired();
            builder.HasOne(_ => _.StatusExame).WithMany().IsRequired();
            builder.HasOne(_ => _.LaboratorioRealizouExame);
        }
    }
}
