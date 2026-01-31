using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                            .HasMaxLength(150)
                            .IsRequired();

            builder.Property(c => c.Email)
                            .HasMaxLength(150)
                            .IsRequired();

            builder.HasIndex(c => c.Email)
                            .IsUnique();

            builder.Property(c => c.Endereco)
                            .IsRequired();

            builder.Property(c => c.SenhaHash)
                            .IsRequired();

            builder.HasMany(c => c.ItensCarrinho)
                            .WithOne()
                            .HasForeignKey(i => i.ClienteId);
        }
    }
}