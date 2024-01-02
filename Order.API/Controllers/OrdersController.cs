using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Order.API.DTOs;
using Order.API.Models;
using Shared;

namespace Order.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IPublishEndpoint _publishEndpoint;

        public OrdersController(AppDbContext context, IPublishEndpoint publishEndpoint)
        {
            _context = context;
            _publishEndpoint = publishEndpoint;
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderCreateDto orderCreateDto)
        {
            var newOrder = new Models.Order
            {
                BuyerId = orderCreateDto.BuyerId,
                Status = OrderStatus.Suspend,
                Address = new Address
                {
                    Line = orderCreateDto.AddressDto.Line,
                    Province = orderCreateDto.AddressDto.Province,
                    District = orderCreateDto.AddressDto.District,
                },
                CreatedDate = DateTime.Now,
            };

            orderCreateDto.OrderItems.ForEach(item =>
            {
                newOrder.Items.Add(new OrderItem
                {
                    Price = item.Price,
                    ProductId = item.ProductId,
                    Count = item.Count,
                });
            });

            await _context.AddAsync(newOrder);
            await _context.SaveChangesAsync();

            var orderCreatedEvent = new OrderCreatedEvent
            {
                BuyerId = orderCreateDto.BuyerId,
                OrderId = newOrder.Id,
                Payment = new PaymentMessage
                {
                    CardName = orderCreateDto.Payment.CardName,
                    CardNumber = orderCreateDto.Payment.CardNumber,
                    Expiration = orderCreateDto.Payment.Expiration,
                    CVV = orderCreateDto.Payment.CVV,
                    TotalPrice = orderCreateDto.OrderItems.Sum(oi => oi.Price * oi.Count)
                },
            };

            orderCreateDto.OrderItems.ForEach(item =>
            {
                orderCreatedEvent.OrderItemMessages.Add(new OrderItemMessage
                {
                    Count = item.Count,
                    ProductId = item.ProductId
                });
            });

            await _publishEndpoint.Publish(orderCreatedEvent);

            return Ok();
        }
    }
}
