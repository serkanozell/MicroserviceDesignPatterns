﻿namespace Shared
{
    public class RabbitMQSettingsConst
    {
        public const string StockOrderCreatedEventQueueName = "stock-order-created-queue";
        public const string StockReservedEventQueueName = "stock-reserved-queue";
        public const string StockNotReservedEventQueueName = "order-stock-not-reserved-queue";
        public const string StockPaymentFailedEventQueueName = "stock-payment-failed-queue";

        public const string OrderPaymentCompletedEventQueueName = "order-payment-completed-queue";
        public const string OrderPaymentFailedEventQueueName = "order-payment-failed-queue";
    }
}
