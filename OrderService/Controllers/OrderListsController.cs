using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using OrderService.Models;

namespace OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderListsController : ControllerBase
    {
        private readonly IMongoCollection<OrderLists> _orderlistssCollection;
        public OrderListsController(DbContext dbContext)
        {
            _orderlistssCollection = dbContext.OrderLists;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderLists>>> GetOrderLists()
        {
            return await _orderlistssCollection.Find(Builders<OrderLists>.Filter.Empty).ToListAsync();
        }

        [HttpGet("{orderlistsId}")]
        public async Task<ActionResult<OrderLists>> GetById(string orderlistsId)
        {
            var fillerDefinition = Builders<OrderLists>.Filter.Eq(x => x.OrderId, orderlistsId);
            return await _orderlistssCollection.Find(fillerDefinition).SingleOrDefaultAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Create(OrderLists orderlistss)
        {
            await _orderlistssCollection.InsertOneAsync(orderlistss);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update(OrderLists orderlistss)
        {
            var fillerDefinition = Builders<OrderLists>.Filter.Eq(x => x.OrderId, orderlistss.OrderId);
            await _orderlistssCollection.ReplaceOneAsync(fillerDefinition, orderlistss);
            return Ok();
        }

        [HttpDelete("{orderlistsId}")]
        public async Task<ActionResult> Delete(string orderlistsId)
        {
            var fillerDefinition = Builders<OrderLists>.Filter.Eq(x => x.OrderId, orderlistsId);
            await _orderlistssCollection.DeleteOneAsync(fillerDefinition);
            return Ok();
        }
    }
}
