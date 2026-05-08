namespace AbySalto.Junior.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }

        public string CustomerName { get; set; } = null!;

        public string Status { get; set; } = null!;

        public DateTime OrderTime { get; set; }

        public string PaymentMethod { get; set; } = null!;

        public string DeliveryAddress { get; set; } = null!;

        public string ContactNumber { get; set; } = null!;

        public string? Note { get; set; }

        public decimal TotalAmount { get; set; }

        public string Currency { get; set; } = null!;

        public List<OrderItemDto> Items { get; set; } = new();
    }
}