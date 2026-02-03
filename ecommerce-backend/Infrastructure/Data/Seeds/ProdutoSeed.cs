using Domain.Entities;
using Domain.Enums;
using Infrastructure.Data;

namespace Infrastructure.Data.Seeds
{
    public static class ProdutoSeed
    {
        public static void Seed(EcommerceDbContext context)
        {
            if (context.Produtos.Any())
                return;

            var produtos = new List<Produto>
            {
                new Produto(
                    "Notebook Dell Inspiron",
                    "Notebook i5, 16GB RAM, SSD 512GB",
                    4599.90m,
                    10,
                    ECategoria.Notebook
                ),
                new Produto(
                    "Mouse Logitech G203",
                    "Mouse gamer RGB 8000 DPI",
                    129.90m,
                    50,
                    ECategoria.Periféricos
                ),
                new Produto(
                    "Teclado Mecânico Redragon",
                    "Switch Red, ABNT2",
                    299.90m,
                    30,
                    ECategoria.Periféricos
                ),
                new Produto(
                    "Monitor LG 24''",
                    "Full HD IPS 75Hz",
                    899.90m,
                    15,
                    ECategoria.Hardware
                )
            };

            context.Produtos.AddRange(produtos);
            context.SaveChanges();
        }
    }
}
