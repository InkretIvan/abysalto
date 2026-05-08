namespace AbySalto.Junior.Dtos
{
    public class CreateOrderDto
    {
        public string CustomerName { get; set; } = null!;

        public string PaymentMethod { get; set; } = null!;

        public string DeliveryAddress { get; set; } = null!;

        public string ContactNumber { get; set; } = null!;

        public string? Note { get; set; }

        public List<CreateOrderItemDto> Items { get; set; } = new();
    }

    public class CreateOrderItemDto
    {
        public string Name { get; set; } = null!;

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}