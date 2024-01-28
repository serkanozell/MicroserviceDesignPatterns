using MassTransit;

namespace Shared.Interfaces
{
    public interface IStockReservedEvent : CorrelatedBy<Guid>
    {
        public List<OrderItemMessage> OrderItems { get; set; }
    }
}
