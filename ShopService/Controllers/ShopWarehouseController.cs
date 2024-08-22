using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopService.Models;

namespace ShopService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopWarehouseController : ControllerBase
    {
        private readonly DbContext _dbContext;
        public ShopWarehouseController(DbContext shopwarehouseDbContext)
        {
            _dbContext = shopwarehouseDbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ShopWarehouse>> GetShopWarehouse()
        {
            return _dbContext.ShopWarehouse;
        }

        [HttpGet("{shopwarehouseId}")]
        public async Task<ActionResult<ShopWarehouse>> GetById(string shopwarehouseId)
        {
            var shopwarehouse = await _dbContext.ShopWarehouse.FindAsync(shopwarehouseId);
            return shopwarehouse;
        }

        [HttpPost]
        public async Task<ActionResult> Create(ShopWarehouse shopwarehouse)
        {
            await _dbContext.ShopWarehouse.AddAsync(shopwarehouse);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update(ShopWarehouse shopwarehouse)
        {
            _dbContext.ShopWarehouse.Update(shopwarehouse);
            await _dbContext.SaveChangesAsync();
            return Ok();

        }

        [HttpDelete]
        public async Task<ActionResult> Delete(string shopwarehouseId)
        {
            var shopwarehouse = await _dbContext.ShopWarehouse.FindAsync(shopwarehouseId);
            _dbContext.ShopWarehouse.Remove(shopwarehouse);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
