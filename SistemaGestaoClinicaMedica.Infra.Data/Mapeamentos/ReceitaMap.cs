using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using System;

namespace SistemaGestaoClinicaMedica.Infra.Data.Mapeamentos
{
    public class ReceitaMap : MapeamentoBase<Guid, Receita>
    {
        public override void Configure(EntityTypeBuilder<Receita> builder)
        {
            base.Configure(builder);

            builder.Property(_ => _.Observacao).HasMaxLength(500).IsRequired();

            builder.HasMany(_ => _.Medicamentos);
        }
    }
}
