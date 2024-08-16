using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserService.Models;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DbContext _dbContext;
        public UserController(DbContext userDbContext)
        {
            _dbContext = userDbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Users>> GetUsers()
        {
            return _dbContext.Users;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<Users>> GetById(string userId)
        {
            var user = await _dbContext.Users.FindAsync(userId);
            return user;
        }

        [HttpPost]
        public async Task<ActionResult> Create(Users user)
        {
            if ((await _dbContext.Roles.FindAsync(user.RoleId)) is null) return NotFound();
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update(Users user)
        {
            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();
            return Ok();

        }

        [HttpDelete]
        public async Task<ActionResult> Delete(string userId)
        {
            var user = await _dbContext.Users.FindAsync(userId);
            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

    }
}
