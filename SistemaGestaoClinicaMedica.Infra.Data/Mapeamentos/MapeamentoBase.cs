using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaGestaoClinicaMedica.Dominio.Entidades;

namespace SistemaGestaoClinicaMedica.Infra.Data.Mapeamentos
{
    public abstract class MapeamentoBase<TId, TEntidade> : IEntityTypeConfiguration<TEntidade>
        where TEntidade : class, IEntidade<TId>
    {
        public virtual void Configure(EntityTypeBuilder<TEntidade> builder)
        {
            builder.HasKey(_ => _.Id);
        }
    }
}
