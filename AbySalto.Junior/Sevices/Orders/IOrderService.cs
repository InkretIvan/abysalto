using AbySalto.Junior.Dtos;
using AbySalto.Junior.Models;

namespace AbySalto.Junior.Services.Orders
{
    public interface IOrderService
    {
        Task<int> CreateOrderAsync(CreateOrderDto dto);

        Task<List<OrderDto>> GetOrdersAsync(bool sortByTotal);

        Task<bool> UpdateStatusAsync(int orderId, OrderStatus status);

        Task DeleteAllAsync();
    }
}