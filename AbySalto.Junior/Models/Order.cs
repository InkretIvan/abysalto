namespace AbySalto.Junior.Models
{
    public class Order
    {
        public int Id { get; set; }

        public string CustomerName { get; set; } = null!;

        public OrderStatus Status { get; set; }

        public DateTime OrderTime { get; set; }

        public string PaymentMethod { get; set; } = null!;

        public string DeliveryAddress { get; set; } = null!;

        public string ContactNumber { get; set; } = null!;

        public string? Note { get; set; }

        public List<OrderItem> Items { get; set; } = new();

        public decimal TotalAmount { get; set; }

        public string Currency { get; set; } = "EUR";
    }
}