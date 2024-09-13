using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using OrderService.Models;

namespace OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMongoCollection<Orders> _ordersCollection;
        public OrdersController(DbContext dbContext)
        {
            _ordersCollection = dbContext.Orders;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Orders>>> GetOrders()
        {
            return await _ordersCollection.Find(Builders<Orders>.Filter.Empty).ToListAsync();
        }

        [HttpGet("{orderId}")]
        public async Task<ActionResult<Orders>> GetById(string orderId)
        {
            var fillerDefinition = Builders<Orders>.Filter.Eq(x => x.OrderId, orderId);
            return await _ordersCollection.Find(fillerDefinition).SingleOrDefaultAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Orders orders)
        {
            await _ordersCollection.InsertOneAsync(orders);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update(Orders orders)
        {
            var fillerDefinition = Builders<Orders>.Filter.Eq(x => x.OrderId, orders.OrderId);
            await _ordersCollection.ReplaceOneAsync(fillerDefinition, orders);
            return Ok();
        }

        [HttpDelete("{orderId}")]
        public async Task<ActionResult> Delete(string orderId)
        {
            var fillerDefinition = Builders<Orders>.Filter.Eq(x => x.OrderId, orderId);
            await _ordersCollection.DeleteOneAsync(fillerDefinition);
            return Ok();
        }
    }
}
