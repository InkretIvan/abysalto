using AbySalto.Junior.Dtos;
using AbySalto.Junior.Services.Orders;
using Microsoft.AspNetCore.Mvc;

namespace AbySalto.Junior.Controllers
{
    [ApiController]
    [Route("api/restaurant")]
    public class RestaurantController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public RestaurantController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("orders")]
        public async Task<IActionResult> CreateOrder(
            [FromBody] CreateOrderDto dto)
        {
            if (dto.Items.Count == 0)
            {
                return BadRequest("Order must contain items");
            }

            var orderId =
                await _orderService.CreateOrderAsync(dto);

            return Ok(new
            {
                Id = orderId,
                Message = "Order created successfully"
            });
        }

        [HttpGet("orders")]
        public async Task<IActionResult> GetOrders([FromQuery] bool sortByTotal = false)
        {
            var orders = await _orderService.GetOrdersAsync(sortByTotal);
            return Ok(orders);
        }

        [HttpPut("orders/{id}/status")]
        public async Task<IActionResult> UpdateStatus(
            int id,
            [FromBody] UpdateOrderStatusDto dto)
        {
            var result = await _orderService.UpdateStatusAsync(id, dto.Status);

            if (!result)
                return NotFound("Order not found or cannot be updated");

            return Ok(new
            {
                Message = "Status updated successfully"
            });
        }

        [HttpDelete("orders")]
        public async Task<IActionResult> DeleteAll()
        {
            await _orderService.DeleteAllAsync();

            return Ok(new
            {
                Message = "All orders deleted successfully"
            });
        }
    }
}