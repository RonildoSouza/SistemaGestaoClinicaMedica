using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using System;

namespace SistemaGestaoClinicaMedica.Infra.Data.Mapeamentos
{
    public class ConsultaMap : MapeamentoBase<Guid, Consulta>
    {
        public override void Configure(EntityTypeBuilder<Consulta> builder)
        {
            base.Configure(builder);

            builder.Property(_ => _.Data).IsRequired();
            builder.Property(_ => _.Observacao).HasMaxLength(1000);

            builder.HasOne(_ => _.StatusConsulta).WithMany().IsRequired();
            builder.HasOne(_ => _.Paciente).WithMany().IsRequired();
            builder.HasOne(_ => _.Medico).WithMany().IsRequired();
            builder.HasOne(_ => _.Especialidade).WithMany().IsRequired();
            builder.HasOne(_ => _.Receita).WithOne(_ => _.Consulta).HasForeignKey<Receita>("ConsultaId").IsRequired();

            builder.HasMany(_ => _.Atestados).WithOne(_ => _.Consulta).IsRequired();
            builder.HasMany(_ => _.Exames).WithOne(_ => _.Consulta).IsRequired();
        }
    }
}
