using Domain.Enums;

namespace Domain.Entities
{
    public class Pedido
    {
        public int Id { get; private set; }
        public DateTime DataPedido { get; private set; }
        public decimal ValorTotal { get; private set; }

        public int ClienteId { get; private set; }
        public Cliente Cliente { get; private set; }

        private readonly List<ItemPedido> _itens = new();
        public IReadOnlyCollection<ItemPedido> Itens => _itens;

        public EStatusEntrega StatusEntrega { get; private set; }

        protected Pedido() { }

        public Pedido(int clienteId)
        {
            ClienteId = clienteId;
            DataPedido = DateTime.UtcNow;
            StatusEntrega = EStatusEntrega.AguardandoSeparacao;
        }

        public void AdicionarItem(ItemPedido item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            var itemExistente = _itens
                .FirstOrDefault(i => i.ProdutoId == item.ProdutoId);

            if (itemExistente != null)
            {
                itemExistente.AumentarQuantidade(item.Quantidade);
            }
            else
            {
                _itens.Add(item);
            }

            RecalcularTotal();
        }

        private void RecalcularTotal()
        {
            ValorTotal = _itens.Sum(i => i.PrecoUnitario * i.Quantidade);
        }

        public void AvancarStatus()
        {
            StatusEntrega = StatusEntrega switch
            {
                EStatusEntrega.AguardandoSeparacao => EStatusEntrega.EmSeparacao,
                EStatusEntrega.EmSeparacao => EStatusEntrega.Enviado,
                EStatusEntrega.Enviado => EStatusEntrega.Entregue,
                _ => throw new InvalidOperationException("Pedido já finalizado.")
            };
        }
    }
}
