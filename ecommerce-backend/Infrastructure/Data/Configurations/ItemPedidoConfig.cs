using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ItemPedidoConfiguration : IEntityTypeConfiguration<ItemPedido>
{
    public void Configure(EntityTypeBuilder<ItemPedido> builder)
    {
        builder.ToTable("ItensPedido");

        builder.HasKey(i => i.Id);

        builder.Property(i => i.NomeProduto)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(i => i.PrecoUnitario)
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(i => i.Quantidade)
            .IsRequired();

        builder.HasOne(i => i.Pedido)
            .WithMany(p => p.Itens)
            .HasForeignKey(i => i.PedidoId);
    }
}