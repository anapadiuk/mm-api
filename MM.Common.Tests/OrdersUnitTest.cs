using AutoMapper;
using MM.Common.Services;
using MM.Core.Contracts.Entities;
using MM.Database;
using MM.Orders.Contracts.Entities;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MM.Orders.Contracts.Models;
using Xunit;
using Moq.EntityFrameworkCore;

namespace MM.Common.Tests
{
    public class OrdersUnitTest
    {
        private readonly Mock<MMDbContext> _db;

        public OrdersUnitTest()
        {
            var customers = new List<Customer>()
            {
                new Customer {Id = 1, Name = "Customer #1"},
                new Customer {Id = 2, Name = "Customer #2"},
                new Customer {Id = 3, Name = "Customer #3"},
                new Customer {Id = 4, Name = "Customer #4"}
            };
            var products = new List<Product>()
            {
                new Product {Id = 1, Name = "Product #1"},
                new Product {Id = 2, Name = "Product #2"},
                new Product {Id = 3, Name = "Product #3"},
                new Product {Id = 4, Name = "Product #4"}
            };
            var orders = new List<Order>()
            {
                new Order
                {
                    Id = 1, CustomerId = 1, ProductId = 1, Quantity = 10, Customer = customers.Single(x => x.Id == 1),
                    Product = products.Single(x => x.Id == 1)
                },
                new Order
                {
                    Id = 2, CustomerId = 2, ProductId = 2, Quantity = 20, Customer = customers.Single(x => x.Id == 2),
                    Product = products.Single(x => x.Id == 2)
                }
            };

            _db = new Mock<MMDbContext>();
            _db.Setup(x => x.Set<Product>()).ReturnsDbSet(products.AsQueryable());
            _db.Setup(x => x.Set<Customer>()).ReturnsDbSet(customers.AsQueryable());
            _db.Setup(x => x.Set<Order>()).ReturnsDbSet(orders.AsQueryable());
        }

        [Fact]
        public async Task ViewModelGetterTest()
        {
            InitMapper();
            var getter = new EntityGetter<Order, OrderItemViewModel>(_db.Object);
            var order = await getter.GetAsync(1, x => x.Customer, y => y.Product);
            Assert.NotNull(order);
            Assert.Equal(1, order.Id);
        }

        [Fact]
        public async Task EntityGetterTest()
        {
            var getter = new EntityGetter<Order>(_db.Object);
            var order = await getter.GetAsync(1);
            Assert.NotNull(order);
            Assert.Equal(1, order.Id);
        }

        [Fact]
        public async Task EntityCreatorTest()
        {
            var model = new OrderBindingModel()
            {
                CustomerId = 3,
                ProductId = 3,
                Quantity = 30
            };
            var creator = new EntityCreator<OrderBindingModel, Order>(_db.Object);
            var order = await creator.CreateAsync(model);
            Assert.NotNull(order);
            Assert.Equal(model.Quantity, order.Quantity);
        }

        [Fact]
        public async Task EntityUpdaterTest()
        {
            var model = new OrderQuantityBindingModel()
            {
                Quantity = 100
            };
            var updater = new EntityUpdater<OrderQuantityBindingModel, Order>(_db.Object);
            var order = await updater.UpdateAsync(1, model);
            Assert.NotNull(order);
            Assert.Equal(model.Quantity, order.Quantity);
        }

        [Fact]
        public async Task EntityDeleterTest()
        {
            var deleter = new EntityDeleter<Order>(_db.Object);
            var order = await deleter.DeleteAsync(1);
            Assert.NotNull(order);
            Assert.Equal(1, order.Id);
        }

        [Fact]
        public async Task EntityCollectionTest()
        {
            InitMapper();
            var getter = new EntityCollectionGetter<Order, OrderItemViewModel>(_db.Object);
            var orders = await getter.GetAsync(x => x.Quantity > 15, x => x.Customer, y => y.Product);
            Assert.NotNull(orders);
            Assert.Single(orders);
        }

        private void InitMapper()
        {
            Mapper.Reset();
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