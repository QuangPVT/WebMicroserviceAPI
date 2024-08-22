using BlogService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogTypeController : ControllerBase
    {
        private readonly DbContext _dbContext;
        public BlogTypeController(DbContext blogtypeDbContext)
        {
            _dbContext = blogtypeDbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<BlogType>> GetBlogTypes()
        {
            return _dbContext.BlogType;
        }

        [HttpGet("{blogtypeId}")]
        public async Task<ActionResult<BlogType>> GetById(string blogtypeId)
        {
            var blogtype = await _dbContext.BlogType.FindAsync(blogtypeId);
            return blogtype;
        }

        [HttpPost]
        public async Task<ActionResult> Create(BlogType blogtype)
        {
            if ((await _dbContext.BlogType.FindAsync(blogtype.TypeId)) is null) return NotFound();
            await _dbContext.BlogType.AddAsync(blogtype);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update(BlogType blogtype)
        {
            _dbContext.BlogType.Update(blogtype);
            await _dbContext.SaveChangesAsync();
            return Ok();

        }

        [HttpDelete]
        public async Task<ActionResult> Delete(string blogtypeId)
        {
            var blogtype = await _dbContext.BlogType.FindAsync(blogtypeId);
            _dbContext.BlogType.Remove(blogtype);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
