﻿using MassTransit;

namespace Shared.Interfaces
{
    public interface IOrderCreatedEvent : CorrelatedBy<Guid>
    {
        public List<OrderItemMessage> OrderItems { get; set; }
    }
}
