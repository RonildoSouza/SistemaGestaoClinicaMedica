using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaGestaoClinicaMedica.Infra.Data.Mapeamentos
{
    public class ReceitaMap : MapeamentoBase<Guid, Receita>
    {
        //public override void Configure(EntityTypeBuilder<Receita> builder)
        //{
        //    base.Configure(builder);

        //    builder.Property(_ => _.Observacao).HasMaxLength(1000);
        //    builder.Property(_ => _.CriadoEm).ValueGeneratedOnAdd();

        //    builder.HasOne(_ => _.Medicamentos)
        //        .WithMany(_ => _.)
        //}
    }
}
