using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using ProductService.Models;

namespace ProductService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductInfoController : ControllerBase
    {
        private readonly IMongoCollection<ProductInfo> _productinfoCollection;
        public ProductInfoController(DbContext dbContext)
        {
            _productinfoCollection = dbContext.ProductInfo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductInfo>>> GetProductInfo()
        {
            return await _productinfoCollection.Find(Builders<ProductInfo>.Filter.Empty).ToListAsync();
        }

        [HttpGet("{productId}")]
        public async Task<ActionResult<ProductInfo>> GetById(string productId)
        {
            var fillerDefinition = Builders<ProductInfo>.Filter.Eq(x => x.ProductId, productId);
            return await _productinfoCollection.Find(fillerDefinition).SingleOrDefaultAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Create(ProductInfo productinfo)
        {
            await _productinfoCollection.InsertOneAsync(productinfo);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update(ProductInfo productinfo)
        {
            var fillerDefinition = Builders<ProductInfo>.Filter.Eq(x => x.ProductId, productinfo.ProductId);
            await _productinfoCollection.ReplaceOneAsync(fillerDefinition, productinfo);
            return Ok();
        }

        [HttpDelete("{productId}")]
        public async Task<ActionResult> Delete(string productId)
        {
            var fillerDefinition = Builders<ProductInfo>.Filter.Eq(x => x.ProductId, productId);
            await _productinfoCollection.DeleteOneAsync(fillerDefinition);
            return Ok();
        }
    }
}
