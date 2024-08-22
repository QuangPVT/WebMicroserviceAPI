using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopService.Models;

namespace ShopService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopInfoController : ControllerBase
    {
        private readonly DbContext _dbContext;
        public ShopInfoController(DbContext shopinfoDbContext)
        {
            _dbContext = shopinfoDbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ShopInfo>> GetShopInfo()
        {
            return _dbContext.ShopInfo;
        }

        [HttpGet("{shopinfoId}")]
        public async Task<ActionResult<ShopInfo>> GetById(string shopinfoId)
        {
            var shopinfo = await _dbContext.ShopInfo.FindAsync(shopinfoId);
            return shopinfo;
        }

        [HttpPost]
        public async Task<ActionResult> Create(ShopInfo shopinfo)
        {
            await _dbContext.ShopInfo.AddAsync(shopinfo);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update(ShopInfo shopinfo)
        {
            _dbContext.ShopInfo.Update(shopinfo);
            await _dbContext.SaveChangesAsync();
            return Ok();

        }

        [HttpDelete]
        public async Task<ActionResult> Delete(string shopinfoId)
        {
            var shopinfo = await _dbContext.ShopInfo.FindAsync(shopinfoId);
            _dbContext.ShopInfo.Remove(shopinfo);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
