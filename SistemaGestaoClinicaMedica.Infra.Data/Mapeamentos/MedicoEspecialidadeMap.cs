using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using System;

namespace SistemaGestaoClinicaMedica.Infra.Data.Mapeamentos
{
    public class MedicoEspecialidadeMap : MapeamentoBase<Guid, MedicoEspecialidade>
    {
        public override void Configure(EntityTypeBuilder<MedicoEspecialidade> builder)
        {
            base.Configure(builder);

            builder.Property(_ => _.Ativo).HasDefaultValue(true);

            builder.HasOne(_ => _.Medico)
                .WithMany(_ => _.Especialidades)
                .HasForeignKey(_ => _.MedicoId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(_ => _.Especialidade)
                .WithMany(_ => _.Medicos)
                .HasForeignKey(_ => _.EspecialidadeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
