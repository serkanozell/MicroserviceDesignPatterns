using MassTransit;

namespace Shared.Interfaces
{
    public interface IPaymentCompletedEvent : CorrelatedBy<Guid>
    {
    }

    public interface IPaymentFailedEvent : CorrelatedBy<Guid>
    {
        public string Reason { get; set; }
        public List<OrderItemMessage> OrderItems { get; set; }
    }
}
