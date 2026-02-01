using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class ItemCarrinhoConfiguration : IEntityTypeConfiguration<ItemCarrinho>
    {
        public void Configure(EntityTypeBuilder<ItemCarrinho> builder)
        {
            builder.ToTable("ItensCarrinho");

            builder.HasKey(ic => ic.Id);

            builder.Property(ic => ic.Quantidade)
                .IsRequired();

            builder.Property(ic => ic.PrecoUnitario)
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(ic => ic.ClienteId)
                .IsRequired();

            builder.HasOne<Cliente>()
                .WithMany(c => c.ItensCarrinho)
                .HasForeignKey(ic => ic.ClienteId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(ic => ic.ProdutoId)
                .IsRequired();
        }
    }
}
