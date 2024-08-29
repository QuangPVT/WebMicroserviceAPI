using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using ProductService.Models;

namespace ProductService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypeController : ControllerBase
    {
        private readonly IMongoCollection<ProductType> _producttypeCollection;
        public ProductTypeController(DbContext dbContext)
        {
            _producttypeCollection = dbContext.ProductType;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductType>>> GetProductType()
        {
            return await _producttypeCollection.Find(Builders<ProductType>.Filter.Empty).ToListAsync();
        }

        [HttpGet("{productTypeId}")]
        public async Task<ActionResult<ProductType>> GetById(string productTypeId)
        {
            var fillerDefinition = Builders<ProductType>.Filter.Eq(x => x.ProductTypeId, productTypeId);
            return await _producttypeCollection.Find(fillerDefinition).SingleOrDefaultAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Create(ProductType producttype)
        {
            await _producttypeCollection.InsertOneAsync(producttype);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update(ProductType producttype)
        {
            var fillerDefinition = Builders<ProductType>.Filter.Eq(x => x.ProductTypeId, producttype.ProductTypeId);
            await _producttypeCollection.ReplaceOneAsync(fillerDefinition, producttype);
            return Ok();
        }

        [HttpDelete("{productTypeId}")]
        public async Task<ActionResult> Delete(string productTypeId)
        {
            var fillerDefinition = Builders<ProductType>.Filter.Eq(x => x.ProductTypeId, productTypeId);
            await _producttypeCollection.DeleteOneAsync(fillerDefinition);
            return Ok();
        }
    }
}
