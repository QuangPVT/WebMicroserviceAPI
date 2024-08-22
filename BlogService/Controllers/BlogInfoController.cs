using BlogService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogInfoController : ControllerBase
    {
        private readonly DbContext _dbContext;
        public BlogInfoController(DbContext bloginfoDbContext)
        {
            _dbContext = bloginfoDbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<BlogInfo>> GetBlogInfos()
        {
            return _dbContext.BlogInfo;
        }

        [HttpGet("{bloginfoId}")]
        public async Task<ActionResult<BlogInfo>> GetById(string bloginfoId)
        {
            var bloginfo = await _dbContext.BlogInfo.FindAsync(bloginfoId);
            return bloginfo;
        }

        [HttpPost]
        public async Task<ActionResult> Create(BlogInfo bloginfo)
        {
            if ((await _dbContext.BlogInfo.FindAsync(bloginfo.TypeId)) is null) return NotFound();
            await _dbContext.BlogInfo.AddAsync(bloginfo);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update(BlogInfo bloginfo)
        {
            _dbContext.BlogInfo.Update(bloginfo);
            await _dbContext.SaveChangesAsync();
            return Ok();

        }

        [HttpDelete]
        public async Task<ActionResult> Delete(string bloginfoId)
        {
            var bloginfo = await _dbContext.BlogInfo.FindAsync(bloginfoId);
            _dbContext.BlogInfo.Remove(bloginfo);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
