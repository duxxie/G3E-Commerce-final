using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
{
    public void Configure(EntityTypeBuilder<Pedido> builder)
    {
        builder.ToTable("Pedidos");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.DataPedido)
            .IsRequired();

        builder.Property(p => p.ValorTotal)
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(p => p.StatusEntrega)
            .HasConversion<string>()
            .IsRequired();

        builder.HasMany(p => p.Itens)
            .WithOne(i => i.Pedido)
            .HasForeignKey(i => i.PedidoId);
    }
}
