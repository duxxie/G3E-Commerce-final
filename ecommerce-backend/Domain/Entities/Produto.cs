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
    }  
}