using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using System;

namespace SistemaGestaoClinicaMedica.Infra.Data.Mapeamentos
{
    public class LaboratorioMap : MapeamentoBase<Guid, Laboratorio>
    {
        public override void Configure(EntityTypeBuilder<Laboratorio> builder)
        {
            base.Configure(builder);

            builder.Property(_ => _.DaClinica).IsRequired();

            builder.HasOne(_ => _.Funcionario).WithMany().IsRequired();
        }
    }
}
