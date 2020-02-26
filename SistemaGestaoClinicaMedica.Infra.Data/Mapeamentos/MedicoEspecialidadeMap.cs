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

            builder.HasOne(_ => _.Medico)
                .WithMany(_ => _.Especialidades)
                .HasForeignKey(_ => _.EspecialidadeId);

            builder.HasOne(_ => _.Especialidade)
                .WithMany(_ => _.Medicos)
                .HasForeignKey(_ => _.MedicoId);

            //modelBuilder.Entity<PostTag>()
            //.HasOne(pt => pt.Post)
            //.WithMany(p => p.PostTags)
            //.HasForeignKey(pt => pt.PostId);

            //modelBuilder.Entity<PostTag>()
            //    .HasOne(pt => pt.Tag)
            //    .WithMany(t => t.PostTags)
            //    .HasForeignKey(pt => pt.TagId);
        }
    }
}
