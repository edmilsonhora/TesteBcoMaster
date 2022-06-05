using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesteBancoMaster.DomainModel;

namespace TesteBancoMaster.DataAccess.Mappings
{
    internal class RotaMap : IEntityTypeConfiguration<Rota>
    {
        public void Configure(EntityTypeBuilder<Rota> builder)
        {
            builder.ToTable("Rotas");
            builder.Property(p => p.Origem).HasMaxLength(50);
            builder.Property(p => p.Destino).HasMaxLength(50);
            builder.Property(p => p.Valor).HasColumnType("Real");

        }
    }
}
