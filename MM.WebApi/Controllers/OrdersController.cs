using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MM.Common.Contracts.Interfaces;
using MM.Orders.Contracts.Entities;
using MM.Orders.Contracts.Models;

namespace MM.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IEntityCollectionGetter<Order, OrderItemViewModel> _collectionGetter;
        private readonly IEntityGetter<Order, OrderItemViewModel> _getter;
        private readonly IEntityCreator<OrderBindingModel, Order> _creator;
        private readonly IEntityUpdater<OrderQuantityBindingModel, Order> _updater;
        private readonly IEntityDeleter<Order> _deleter;
        public OrdersController(IEntityGetter<Order, OrderItemViewModel> getter, 
            IEntityCollectionGetter<Order, OrderItemViewModel> collectionGetter,
            IEntityCreator<OrderBindingModel, Order> creator,
            IEntityUpdater<OrderQuantityBindingModel, Order> updater,
            IEntityDeleter<Order> deleter)
        {
            _getter = getter;
            _collectionGetter = collectionGetter;
            _creator = creator;
            _deleter = deleter;
            _updater = updater;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderItemViewModel>>> Get()
        {
            var list = await _collectionGetter.GetAsync(null, x => x.Product, x => x.Customer);
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderItemViewModel>> Get(int id)
        {
            var entity = await _getter.GetAsync(id, null);
            return Ok(entity);
        }

        [HttpPost]
        public async Task<ActionResult<Order>> Post([FromBody] OrderBindingModel model)
        {
            var entity = await _creator.CreateAsync(model);
            return Ok(entity);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Order>> Put(int id, [FromBody] OrderQuantityBindingModel model)
        {
            var entity = await _updater.UpdateAsync(id, model);
            return Ok(entity);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Order>> Delete(int id)
        {
            return Ok(await _deleter.DeleteAsync(id));
        }
    }
}
