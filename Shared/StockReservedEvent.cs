namespace Shared
{
    public class StockReservedEvent
    {
        public int OrderId { get; set; }
        public string BuyerId { get; set; }
        public PaymentMessage PaymentMessage { get; set; }
        public List<OrderItemMessage> OrderItems { get; set; } = new List<OrderItemMessage>();
    }
}
