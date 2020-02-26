using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using System;

namespace SistemaGestaoClinicaMedica.Infra.Data.Mapeamentos
{
    public class EspecialidadeMap : MapeamentoBase<Guid, Especialidade>
    {
        public override void Configure(EntityTypeBuilder<Especialidade> builder)
        {
            base.Configure(builder);

            builder.Property(_ => _.Nome).HasMaxLength(500);

            builder.HasData(new Especialidade[]
            {
                new Especialidade("Clínica Médica"),
                new Especialidade("Cirurgia Geral"),
                new Especialidade("Pediatria"),
                new Especialidade("Ginecologia e Obstetrícia"),
                new Especialidade("Anestesiologia"),
                new Especialidade("Ortopedia e Traumatologia"),
                new Especialidade("Oftalmologia"),
                new Especialidade("Cardiologia"),
                new Especialidade("Radiologia e Diagnóstico por Imagem"),
                new Especialidade("Psiquiatria"),
                new Especialidade("Dermatologia"),
                new Especialidade("Otorrinolaringologia"),
                new Especialidade("Medicina de Família e Comunidade"),
                new Especialidade("Endocrinologia e Metabologia"),
                new Especialidade("Cirurgia Plástica"),
                new Especialidade("Infectologia"),
                new Especialidade("Cirurgia Vascular"),
                new Especialidade("Urologia"),
                new Especialidade("Cancerologia"),
                new Especialidade("Nefrologia"),
                new Especialidade("Nutrologia"),
            });
        }
    }
}
