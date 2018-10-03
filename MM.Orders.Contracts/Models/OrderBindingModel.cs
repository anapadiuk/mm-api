namespace MM.Orders.Contracts.Models
{
    public class OrderBindingModel
    {
        public int Quantity { get; set; }

        public int ProductId { get; set; }

        public int CustomerId { get; set; }
    }
}
