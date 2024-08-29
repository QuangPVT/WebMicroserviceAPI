using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using ProductService.Models;

namespace ProductService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMongoCollection<Products> _productsCollection;
        public ProductsController(DbContext dbContext)
        {
            _productsCollection = dbContext.Products;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Products>>> GetProducts()
        {
            return await _productsCollection.Find(Builders<Products>.Filter.Empty).ToListAsync();
        }

        [HttpGet("{productId}")]
        public async Task<ActionResult<Products>> GetById(string productId)
        {
            var fillerDefinition = Builders<Products>.Filter.Eq(x => x.ProductId, productId);
            return await _productsCollection.Find(fillerDefinition).SingleOrDefaultAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Products products)
        {
            await _productsCollection.InsertOneAsync(products);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update(Products products)
        {
            var fillerDefinition = Builders<Products>.Filter.Eq(x => x.ProductId, products.ProductId);
            await _productsCollection.ReplaceOneAsync(fillerDefinition, products);
            return Ok();
        }

        [HttpDelete("{productId}")]
        public async Task<ActionResult> Delete(string productId)
        {
            var fillerDefinition = Builders<Products>.Filter.Eq(x => x.ProductId, productId);
            await _productsCollection.DeleteOneAsync(fillerDefinition);
            return Ok();
        }
    }
}
