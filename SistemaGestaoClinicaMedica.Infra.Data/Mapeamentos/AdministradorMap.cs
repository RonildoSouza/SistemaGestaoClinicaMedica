using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using System;

namespace SistemaGestaoClinicaMedica.Infra.Data.Mapeamentos
{
    public class AdministradorMap : MapeamentoBase<Guid, Administrador>
    {
        public override void Configure(EntityTypeBuilder<Administrador> builder)
        {
            base.Configure(builder);

            builder.HasOne(_ => _.Funcionario).WithMany().IsRequired();
        }
    }
}
