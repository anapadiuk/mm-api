using MM.Common.Contracts.Interfaces;
using MM.Core.Contracts.Entities;
using MM.Orders.Contracts.Models;

namespace MM.Orders.Contracts.Entities
{
    public class Order : OrderBindingModel, IEntity
    {
        public int Id { get; set; }

        public Product Product { get; set; }

        public Customer Customer { get; set; }
    }
}
