using Shared.Interfaces;

namespace Shared
{
    public class StockReservedEvent(Guid correlationId) : IStockReservedEvent
    {
        public List<OrderItemMessage> OrderItems { get; set; }

        public Guid CorrelationId { get; } = correlationId;
    }
}
