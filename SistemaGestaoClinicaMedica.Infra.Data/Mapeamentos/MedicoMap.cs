using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using System;

namespace SistemaGestaoClinicaMedica.Infra.Data.Mapeamentos
{
    public class MedicoMap : MapeamentoBase<Guid, Medico>
    {
        public override void Configure(EntityTypeBuilder<Medico> builder)
        {
            base.Configure(builder);

            builder.Property(_ => _.CRM).HasMaxLength(50).IsRequired();

            builder.HasIndex(_ => new { _.CRM }).IsUnique();

            builder.HasOne(_ => _.Funcionario);
            builder.HasMany(_ => _.HorariosDeTrabalho);
        }
    }
}
