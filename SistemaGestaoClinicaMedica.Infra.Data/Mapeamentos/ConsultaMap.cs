using Microsoft.EntityFrameworkCore;
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
            builder.Property(_ => _.Observacao).HasMaxLength(500);
            builder.Property(_ => _.CriadoEm).HasDefaultValueSql("date('now')").ValueGeneratedOnAdd();
            builder.Property(_ => _.AtualizadoEm).HasDefaultValueSql("date('now')").ValueGeneratedOnUpdate();

            builder.HasOne(_ => _.StatusConsulta);
            builder.HasOne(_ => _.Paciente);
            builder.HasOne(_ => _.Medico);
            builder.HasOne(_ => _.Especialidade);
            builder.HasOne(_ => _.Receita);

            builder.HasMany(_ => _.Atestados);
            builder.HasMany(_ => _.Exames);
        }
    }
}
