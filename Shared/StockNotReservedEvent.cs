using Shared.Interfaces;

namespace Shared
{
    public class StockNotReservedEvent(Guid correlationId) : IStockNotReservedEvent
    {
        public string Reason { get; set; }

        public Guid CorrelationId { get; } = correlationId;
    }
}
