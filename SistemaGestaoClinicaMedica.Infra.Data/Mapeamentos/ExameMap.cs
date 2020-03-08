using Microsoft.EntityFrameworkCore;
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

            builder.Property(_ => _.Observacao).HasMaxLength(500);
            builder.Property(_ => _.LinkResultadoExame).HasMaxLength(500);
            builder.Property(_ => _.CriadoEm).HasDefaultValueSql("date('now')").ValueGeneratedOnAdd();

            builder.HasOne(_ => _.TipoDeExame);
            builder.HasOne(_ => _.StatusExame);
            builder.HasOne(_ => _.LaboratorioRealizouExame);
            builder.HasOne(_ => _.Consulta);
        }
    }
}
