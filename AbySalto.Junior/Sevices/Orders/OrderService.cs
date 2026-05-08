using AbySalto.Junior.Dtos;
using AbySalto.Junior.Infrastructure.Database;
using AbySalto.Junior.Models;

namespace AbySalto.Junior.Services.Orders
{
    public class OrderService : IOrderService
    {
        private readonly IApplicationDbContext _db;

        public OrderService(IApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<int> CreateOrderAsync(CreateOrderDto dto)
        {
            var order = new Order
            {
                CustomerName = dto.CustomerName,
                PaymentMethod = dto.PaymentMethod,
                DeliveryAddress = dto.DeliveryAddress,
                ContactNumber = dto.ContactNumber,
                Note = dto.Note,
                OrderTime = DateTime.UtcNow,
                Status = OrderStatus.Pending,

                Items = dto.Items.Select(i => new OrderItem
                {
                    Name = i.Name,
                    Quantity = i.Quantity,
                    Price = i.Price
                }).ToList()
            };

            order.TotalAmount =
                order.Items.Sum(i => i.Price * i.Quantity);

            _db.Orders.Add(order);

            await _db.SaveChangesAsync();

            return order.Id;
        }
    }
}