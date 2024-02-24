using Shared.Interfaces;

namespace Shared.Events
{
    public class PaymentCompletedEvent(Guid correlationId) : IPaymentCompletedEvent
    {
        public Guid CorrelationId { get; } = correlationId;
    }
}
