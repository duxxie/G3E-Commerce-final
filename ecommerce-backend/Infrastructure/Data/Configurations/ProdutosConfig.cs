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

            builder.Property(p => p.Nome);
            
            builder.Property(p => p.Descricao);
            
            builder.Property(p => p.Preco);

            builder.Property(p => p.Estoque);

            builder.Property(p => p.Categoria)
                            .HasConversion<string>()
                            .IsRequired();


            throw new NotImplementedException();
        }
    }
}