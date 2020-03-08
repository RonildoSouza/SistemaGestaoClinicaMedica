//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using SistemaGestaoClinicaMedica.Dominio.Entidades;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace SistemaGestaoClinicaMedica.Infra.Data.Mapeamentos
//{
//    public class ReceitaMap : MapeamentoBase<Guid, Receita>
//    {
//        public override void Configure(EntityTypeBuilder<Receita> builder)
//        {
//            base.Configure(builder);

//            builder.Property(_ => _.Observacao).HasMaxLength(500);
//            builder.Property(_ => _.CriadoEm).HasDefaultValueSql("date('now')").IsRequired();

//            builder.HasOne(_ => _.Medicamentos)
//                .WithMany(_ => _.)
//        }
//    }
//}
