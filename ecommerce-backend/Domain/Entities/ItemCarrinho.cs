namespace Domain.Entities
{
    public class ItemCarrinho
    {
        public int Id { get; private set; }

        public int ClienteId { get; private set; }
        public int ProdutoId { get; private set; }

        public int Quantidade { get; private set; }
        public decimal PrecoUnitario { get; private set; }

        protected ItemCarrinho() { }

        public ItemCarrinho(
            int clienteId,
            int produtoId,
            int quantidade,
            decimal precoUnitario)
        {
            if (clienteId <= 0)
                throw new ArgumentException("Cliente inválido.");

            if (produtoId <= 0)
                throw new ArgumentException("Produto inválido.");

            if (precoUnitario <= 0)
                throw new ArgumentException("Preço deve ser maior que zero.");

            if (quantidade <= 0)
                throw new ArgumentException("Quantidade deve ser maior que zero.");

            ClienteId = clienteId;
            ProdutoId = produtoId;
            Quantidade = quantidade;
            PrecoUnitario = precoUnitario;
        }

        public decimal CalcularTotal()
            => Quantidade * PrecoUnitario;

        internal void AumentarQuantidade(int quantidade)
        {
            if (quantidade <= 0)
                throw new ArgumentException("Quantidade adicional deve ser maior que zero.");

            Quantidade += quantidade;
        }

        internal void DiminuirQuantidade(int quantidade)
        {
            if (quantidade <= 0)
                throw new ArgumentException("Quantidade inválida.");

            if (quantidade >= Quantidade)
                throw new InvalidOperationException("Quantidade não pode zerar ou ficar negativa.");

            Quantidade -= quantidade;
        }
    }
}
