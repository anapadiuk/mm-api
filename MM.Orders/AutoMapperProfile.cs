using AutoMapper;
using MM.Orders.Contracts.Entities;
using MM.Orders.Contracts.Models;

namespace MM.Orders
{
    internal class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Order, OrderItemViewModel>()
                    .ForMember(dto => dto.ProductName, conf => conf.MapFrom(ol => ol.Product.Name))
                    .ForMember(dto => dto.CustomerName, conf => conf.MapFrom(ol => ol.Customer.Name));
                cfg.CreateMap<OrderBindingModel, Order>();
                cfg.CreateMap<OrderQuantityBindingModel, Order>();
                cfg.CreateMap<Order, OrderItemViewModel>();
            });
        }
    }
}
