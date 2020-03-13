using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using System;

namespace SistemaGestaoClinicaMedica.Infra.Data.Mapeamentos
{
    public class ReceitaMedicamentoMap : MapeamentoBase<Guid, ReceitaMedicamento>
    {
        public override void Configure(EntityTypeBuilder<ReceitaMedicamento> builder)
        {
            base.Configure(builder);

            builder.HasOne(_ => _.Receita)
                .WithMany(_ => _.Medicamentos)
                .HasForeignKey(_ => _.ReceitaId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(_ => _.Medicamento)
                .WithMany(_ => _.Receitas)
                .HasForeignKey(_ => _.MedicamentoId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
