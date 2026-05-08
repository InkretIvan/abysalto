namespace AbySalto.Junior.Dtos
{
    public class OrderItemDto
    {
        public string Name { get; set; } = null!;

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}