using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaGestaoClinicaMedica.Dominio.Entidades;

namespace SistemaGestaoClinicaMedica.Infra.Data.Mapeamentos
{
    public class CargoMap : MapeamentoBase<string, Cargo>
    {
        public override void Configure(EntityTypeBuilder<Cargo> builder)
        {
            base.Configure(builder);

            builder.Property(_ => _.Nome).HasMaxLength(500);

            builder.HasIndex(_ => new { _.Id, _.Nome }).IsUnique();
        }
    }
}
