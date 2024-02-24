using Shared.Interfaces;

namespace Shared.Events
{
    public class StockReservedRequestPayment(Guid correlationId) : IStockReservedRequestPayment
    {
        public string BuyerId { get; set; }
        public PaymentMessage Payment { get; set; }
        public List<OrderItemMessage> OrderItems { get; set; }

        public Guid CorrelationId { get; } = correlationId;
    }
}
