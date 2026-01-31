namespace Domain.Entities
{
    public class ItemPedido
    {
        public int Id { get; private set; }

        public int PedidoId { get; private set; }
        public Pedido Pedido { get; private set; } = null!;

        public int ProdutoId { get; private set; }

        // Snapshot
        public string NomeProduto { get; private set; } = string.Empty;
        public decimal PrecoUnitario { get; private set; }

        public int Quantidade { get; private set; }

        protected ItemPedido() { }

        public ItemPedido(
            int produtoId,
            string nomeProduto,
            decimal precoUnitario,
            int quantidade)
        {
            if (string.IsNullOrWhiteSpace(nomeProduto))
                throw new ArgumentException("Nome do produto é obrigatório.");

            if (precoUnitario <= 0)
                throw new ArgumentException("Preço unitário deve ser maior que zero.");

            if (quantidade <= 0)
                throw new ArgumentException("Quantidade deve ser maior que zero.");

            ProdutoId = produtoId;
            NomeProduto = nomeProduto;
            PrecoUnitario = precoUnitario;
            Quantidade = quantidade;
        }

        public decimal CalcularTotal()
            => Quantidade * PrecoUnitario;

        internal void AumentarQuantidade(int quantidade)
        {
            if (quantidade <= 0)
                throw new ArgumentException("Quantidade adicional deve ser maior que zero.");

            Quantidade += quantidade;
        }
    }
}
