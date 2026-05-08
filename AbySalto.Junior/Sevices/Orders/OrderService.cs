using AbySalto.Junior.Dtos;
using AbySalto.Junior.Infrastructure.Database;
using AbySalto.Junior.Models;
using Microsoft.EntityFrameworkCore;

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

        public async Task<List<OrderDto>> GetOrdersAsync(bool sortByTotal)
        {
            var orders = await _db.Orders
                .Include(o => o.Items)
                .ToListAsync();

            if (sortByTotal)
            {
                orders = orders
                    .OrderByDescending(o => o.TotalAmount)
                    .ToList();
            }
            else
            {
                orders = orders
                    .OrderByDescending(o => o.OrderTime)
                    .ToList();
            }

            return orders.Select(Map).ToList();
        }

        public async Task<bool> UpdateStatusAsync(int orderId, OrderStatus status)
        {
            var order = await _db.Orders
                .FirstOrDefaultAsync(o => o.Id == orderId);

            if (order == null)
                return false;

            if (order.Status == OrderStatus.Completed)
                return false; 

            order.Status = status;

            await _db.SaveChangesAsync();

            return true;
        }

        public async Task DeleteAllAsync()
        {
            var orders = await _db.Orders
                .Include(o => o.Items)
                .ToListAsync();

            _db.OrderItems.RemoveRange(_db.OrderItems);
            _db.Orders.RemoveRange(orders);

            await _db.SaveChangesAsync();
        }

        private static OrderDto Map(Order order)
        {
            return new OrderDto
            {
                Id = order.Id,
                CustomerName = order.CustomerName,
                Status = order.Status.ToString(),
                OrderTime = order.OrderTime,
                PaymentMethod = order.PaymentMethod,
                DeliveryAddress = order.DeliveryAddress,
                ContactNumber = order.ContactNumber,
                Note = order.Note,
                TotalAmount = order.TotalAmount,
                Currency = order.Currency,
                Items = order.Items.Select(i => new OrderItemDto
                {
                    Name = i.Name,
                    Quantity = i.Quantity,
                    Price = i.Price
                }).ToList()
            };
        }
    }
}