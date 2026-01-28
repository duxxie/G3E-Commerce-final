namespace Domain.Entities
{
    public class Cliente
    {
        public int Id { get; private set; }

        public string Nome { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string SenhaHash { get; private set; } = string.Empty;
        public string Telefone { get; private set; } = string.Empty;
        public string Endereco { get; private set; } = string.Empty;

        private readonly List<ItemCarrinho> _itensCarrinho = new();
        public IReadOnlyCollection<ItemCarrinho> ItensCarrinho => _itensCarrinho;

        // EF Core
        protected Cliente() { }

        public Cliente(
            string nome,
            string email,
            string senhaHash,
            string telefone,
            string endereco)
        {
            Nome = nome;
            Email = email;
            SenhaHash = senhaHash;
            Telefone = telefone;
            Endereco = endereco;
        }
    }
}
