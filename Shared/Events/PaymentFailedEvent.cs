using Shared.Interfaces;

namespace Shared.Events
{
    public class PaymentFailedEvent(Guid correlationId) : IPaymentFailedEvent
    {
        public List<OrderItemMessage> OrderItems { get; set; }
        public string Reason { get; set; }

        public Guid CorrelationId { get; } = correlationId;
    }
}
