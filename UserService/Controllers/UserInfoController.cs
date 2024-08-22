using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserService.Models;
using static UserService.Models.UserInfo;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInfoController : ControllerBase
    {
        private readonly DbContext _dbContext;
        public UserInfoController(DbContext userinfoDbContext)
        {
            _dbContext = userinfoDbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserInfo>> GetUsers()
        {
            return _dbContext.UserInfo;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<UserInfo>> GetById(string userId)
        {
            var userinfo = await _dbContext.UserInfo.FindAsync(userId);
            return userinfo;
        }

        [HttpPost]
        public async Task<ActionResult> Create(UserInfo userinfo)
        {
            if ((await _dbContext.Users.FindAsync(userinfo.UserId)) is null) return NotFound();
            await _dbContext.UserInfo.AddAsync(userinfo);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update(UserInfo userinfo)
        {
            _dbContext.UserInfo.Update(userinfo);
            await _dbContext.SaveChangesAsync();
            return Ok();

        }

        [HttpDelete]
        public async Task<ActionResult> Delete(string userId)
        {
            var userinfo = await _dbContext.UserInfo.FindAsync(userId);
            _dbContext.UserInfo.Remove(userinfo);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
