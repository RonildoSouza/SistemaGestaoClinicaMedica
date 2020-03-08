using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SistemaGestaoClinicaMedica.Dominio.Entidades;

namespace SistemaGestaoClinicaMedica.Infra.Data.Mapeamentos
{
    public class StatusConsultaMap : MapeamentoBase<EStatusConsulta, StatusConsulta>
    {
        public override void Configure(EntityTypeBuilder<StatusConsulta> builder)
        {
            base.Configure(builder);

            builder.Property(_ => _.Id).HasConversion(new EnumToStringConverter<EStatusConsulta>());
            builder.Property(_ => _.Nome).HasMaxLength(500);

            builder.HasIndex(_ => new { _.Id, _.Nome }).IsUnique();
        }
    }
}
