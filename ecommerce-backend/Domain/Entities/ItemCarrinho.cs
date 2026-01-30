namespace Domain.Entities
{
    public class ItemCarrinho
    {
        public int Id { get; private set; } // Primary key
        public int ClienteId { get; private set; } // Foreign Key
        public int ProdutoId { get; private set; } // Foreign Key
        public Produto? Produtos { get; private set; }
        public int Quantidade { get; private set; }
        public decimal PrecoUnitario { get; private set; }
    }
}