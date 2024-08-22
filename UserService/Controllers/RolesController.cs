using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserService.Models;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly DbContext _dbContext;

        public RolesController(DbContext roleDbContext)
        {
            _dbContext = roleDbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Roles>> GetRoles()
        {
            return _dbContext.Roles;
        }

        [HttpGet("{roleId}")]
        public async Task<ActionResult<Roles>> GetById(string roleId)
        {
            var role = await _dbContext.Roles.FindAsync(roleId);
            return role;
        }

        [HttpPost]
        public async Task<ActionResult> Create(Roles role)
        {
            await _dbContext.Roles.AddAsync(role);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update(Roles role)
        {
            _dbContext.Roles.Update(role);
            await _dbContext.SaveChangesAsync();
            return Ok();

        }

        [HttpDelete]
        public async Task<ActionResult> Delete(string roleId)
        {
            var role = await _dbContext.Roles.FindAsync(roleId);
            _dbContext.Roles.Remove(role);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
