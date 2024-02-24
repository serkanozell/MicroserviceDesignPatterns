using Shared.Interfaces;

namespace Shared.Events
{
    public class OrderCreatedEvent(Guid correlationId) : IOrderCreatedEvent
    {
        public Guid CorrelationId { get; } = correlationId;
        public List<OrderItemMessage> OrderItems { get; set; }
    }
}
