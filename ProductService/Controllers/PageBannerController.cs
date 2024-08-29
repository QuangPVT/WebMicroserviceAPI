using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using ProductService.Models;

namespace ProductService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PageBannerController : ControllerBase
    {
        private readonly IMongoCollection<PageBanner> _pagebannerCollection;
        public PageBannerController(DbContext dbContext)
        {
            _pagebannerCollection = dbContext.PageBanner;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PageBanner>>> GetPageBanner()
        {
            return await _pagebannerCollection.Find(Builders<PageBanner>.Filter.Empty).ToListAsync();
        }

        [HttpGet("{bannerId}")]
        public async Task<ActionResult<PageBanner>> GetById(string bannerId)
        {
            var fillerDefinition = Builders<PageBanner>.Filter.Eq(x => x.BannerId, bannerId);
            return await _pagebannerCollection.Find(fillerDefinition).SingleOrDefaultAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Create(PageBanner pagebanner)
        {
            await _pagebannerCollection.InsertOneAsync(pagebanner);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update(PageBanner pagebanner)
        {
            var fillerDefinition = Builders<PageBanner>.Filter.Eq(x => x.BannerId, pagebanner.BannerId);
            await _pagebannerCollection.ReplaceOneAsync(fillerDefinition, pagebanner);
            return Ok();
        }

        [HttpDelete("{bannerId}")]
        public async Task<ActionResult> Delete(string bannerId)
        {
            var fillerDefinition = Builders<PageBanner>.Filter.Eq(x => x.BannerId, bannerId);
            await _pagebannerCollection.DeleteOneAsync(fillerDefinition);
            return Ok();
        }
    }
}
