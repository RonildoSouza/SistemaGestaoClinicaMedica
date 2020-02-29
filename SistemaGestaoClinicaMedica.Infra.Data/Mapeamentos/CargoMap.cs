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

            builder.HasData(new Cargo[] {
                new Cargo("Administrador", "Administrador"),
                new Cargo("Medico", "Médico"),
                new Cargo("Recepcionista", "Recepcionista"),
                new Cargo("Laboratorio", "Laboratório"),
            });
        }
    }
}
