﻿namespace Shared.Messages
{
    public interface IStockRollbackMessage
    {
        public List<OrderItemMessage> OrderItems { get; set; }
    }
}
