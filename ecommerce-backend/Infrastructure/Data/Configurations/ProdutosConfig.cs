using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class ProdutosConfig : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produto");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .HasMaxLength(150)
                .IsRequired();
            
            builder.Property(p => p.Descricao)
                .HasMaxLength(500);
            
            builder.Property(p => p.Preco)
                .IsRequired();

            builder.Property(p => p.Estoque);

            builder.Property(p => p.Categoria)
                .HasConversion<string>()
                .IsRequired();

        }
    }
}