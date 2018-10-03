using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MM.Common.Contracts.Interfaces;
using MM.Core.Contracts.Entities;

namespace MM.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IEntityCollectionGetter<Customer> _collectionGetter;
        public CustomersController(IEntityCollectionGetter<Customer> collectionGetter)
        {
            _collectionGetter = collectionGetter;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> Get()
        {
            var list = await _collectionGetter.GetAsync(null);
            return Ok(list);
        }
    }
}
