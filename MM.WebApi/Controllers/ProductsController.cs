using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MM.Common.Contracts.Interfaces;
using MM.Core.Contracts.Entities;

namespace MM.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IEntityCollectionGetter<Product> _collectionGetter;
        public ProductsController(IEntityCollectionGetter<Product> collectionGetter)
        {
            _collectionGetter = collectionGetter;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            var list = await _collectionGetter.GetAsync(null);
            return Ok(list);
        }
    }
}
