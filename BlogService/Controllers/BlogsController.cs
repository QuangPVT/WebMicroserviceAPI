using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlogService.Models;

namespace BlogService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly DbContext _dbContext;
        public BlogsController(DbContext blogDbContext)
        {
            _dbContext = blogDbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Blogs>> GetBlogs()
        {
            return _dbContext.Blogs;
        }

        [HttpGet("{blogId}")]
        public async Task<ActionResult<Blogs>> GetById(string blogId)
        {
            var blog = await _dbContext.Blogs.FindAsync(blogId);
            return blog;
        }

        [HttpPost]
        public async Task<ActionResult> Create(Blogs blog)
        {
            if ((await _dbContext.Blogs.FindAsync(blog.BlogId)) is null) return NotFound();
            await _dbContext.Blogs.AddAsync(blog);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update(Blogs blog)
        {
            _dbContext.Blogs.Update(blog);
            await _dbContext.SaveChangesAsync();
            return Ok();

        }

        [HttpDelete]
        public async Task<ActionResult> Delete(string blogId)
        {
            var bloginfo = await _dbContext.BlogInfo.FindAsync(blogId);
            _dbContext.BlogInfo.Remove(bloginfo);
            var blog = await _dbContext.Blogs.FindAsync(blogId);
            _dbContext.Blogs.Remove(blog);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
