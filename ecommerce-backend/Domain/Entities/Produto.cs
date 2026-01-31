using Domain.Enums;

namespace Domain.Entities
{
    public class Produto
    {
        public int Id { get; private set; }
        public string Nome { get; private set; } = string.Empty;
        public string Descricao { get; private set; } = string.Empty;
        public decimal Preco { get; private set; }
        public int Estoque { get; private set; }
        public ECategoria Categoria { get; private set; }

        protected Produto() { }

        public Produto(
            string nome,
            string descricao,
            decimal preco,
            int estoque,
            ECategoria categoria)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome do produto é obrigatório.");

            if (preco <= 0)
                throw new ArgumentException("Preço deve ser maior que zero.");

            if (estoque < 0)
                throw new ArgumentException("Estoque não pode ser negativo.");

            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            Estoque = estoque;
            Categoria = categoria;
        }

        public void AtualizarPreco(decimal novoPreco)
        {
            if (novoPreco <= 0)
                throw new ArgumentException("Preço inválido.");

            Preco = novoPreco;
        }

        public void EntradaEstoque(int quantidade)
        {
            if (quantidade <= 0)
                throw new ArgumentException("Quantidade inválida.");

            Estoque += quantidade;
        }

        public void BaixarEstoque(int quantidade)
        {
            if (quantidade <= 0)
                throw new ArgumentException("Quantidade inválida.");

            if (quantidade > Estoque)
                throw new InvalidOperationException("Estoque insuficiente.");

            Estoque -= quantidade;
        }
    }
}
