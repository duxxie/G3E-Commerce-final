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
                throw new ArgumentException("Nome é obrigatório");

            if (preco <= 0)
                throw new ArgumentException("Preço inválido");

            if (estoque < 0)
                throw new ArgumentException("Estoque inválido");

            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            Estoque = estoque;
            Categoria = categoria;
        }
    }
}