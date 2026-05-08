using AbySalto.Junior.Dtos;

namespace AbySalto.Junior.Services.Orders
{
    public interface IOrderService
    {
        Task<int> CreateOrderAsync(CreateOrderDto dto);
    }
}