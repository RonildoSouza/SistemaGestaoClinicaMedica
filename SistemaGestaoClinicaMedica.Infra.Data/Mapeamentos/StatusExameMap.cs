using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SistemaGestaoClinicaMedica.Dominio.Entidades;

namespace SistemaGestaoClinicaMedica.Infra.Data.Mapeamentos
{
    public class StatusExameMap : MapeamentoBase<EStatusExame, StatusExame>
    {
        public override void Configure(EntityTypeBuilder<StatusExame> builder)
        {
            base.Configure(builder);

            builder.Property(_ => _.Id).HasConversion(new EnumToStringConverter<EStatusExame>());
            builder.Property(_ => _.Nome).HasMaxLength(500);

            builder.HasIndex(_ => new { _.Id, _.Nome }).IsUnique();
        }
    }
}
