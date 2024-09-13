using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using OrderService.Models;

namespace OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDiscountController : ControllerBase
    {
        private readonly IMongoCollection<OrderDiscount> _orderdiscountCollection;
        public OrderDiscountController(DbContext dbContext)
        {
            _orderdiscountCollection = dbContext.OrderDiscount;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDiscount>>> GetOrderDiscount()
        {
            return await _orderdiscountCollection.Find(Builders<OrderDiscount>.Filter.Empty).ToListAsync();
        }

        [HttpGet("{discountId}")]
        public async Task<ActionResult<OrderDiscount>> GetById(string discountId)
        {
            var fillerDefinition = Builders<OrderDiscount>.Filter.Eq(x => x.DiscountId, discountId);
            return await _orderdiscountCollection.Find(fillerDefinition).SingleOrDefaultAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Create(OrderDiscount orderdiscount)
        {
            await _orderdiscountCollection.InsertOneAsync(orderdiscount);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update(OrderDiscount orderdiscount)
        {
            var fillerDefinition = Builders<OrderDiscount>.Filter.Eq(x => x.DiscountId, orderdiscount.DiscountId);
            await _orderdiscountCollection.ReplaceOneAsync(fillerDefinition, orderdiscount);
            return Ok();
        }

        [HttpDelete("{discountId}")]
        public async Task<ActionResult> Delete(string discountId)
        {
            var fillerDefinition = Builders<OrderDiscount>.Filter.Eq(x => x.DiscountId, discountId);
            await _orderdiscountCollection.DeleteOneAsync(fillerDefinition);
            return Ok();
        }
    }
}
