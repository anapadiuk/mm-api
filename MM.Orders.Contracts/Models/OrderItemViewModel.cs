namespace MM.Orders.Contracts.Models
{
    public class OrderItemViewModel: OrderBindingModel
    {
        public int Id { get; set; }

        public string CustomerName { get; set; }

        public string ProductName { get; set; }
    }
}
