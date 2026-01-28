using Domain.Enums;

namespace Domain.Entities
{
    public class Pedido
    {
        public int Id { get; private set; }
        public DateTime DataPedido { get; private set; } = DateTime.UtcNow;
        public decimal ValorTotal { get; private set; }
        public int ClienteId { get; private set; }
        public Cliente? Cliente { get; private set; }

        private readonly List<ItemPedido> _itens = new();
        public IReadOnlyCollection<ItemPedido> Itens => _itens;

        public EStatusEntrega StatusEntrega { get; private set; } = EStatusEntrega.AguardandoSeparacao;
    }
}