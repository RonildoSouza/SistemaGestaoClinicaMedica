using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using System;

namespace SistemaGestaoClinicaMedica.Infra.Data.Mapeamentos
{
    public class RecepcionistaMap : MapeamentoBase<Guid, Recepcionista>
    {
        public override void Configure(EntityTypeBuilder<Recepcionista> builder)
        {
            base.Configure(builder);

            builder.HasOne(_ => _.Funcionario).WithMany().IsRequired();
        }
    }
}
