using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopService.Models;

namespace ShopService.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class StaffsController : ControllerBase
    {
        private readonly DbContext _dbContext;
        public StaffsController(DbContext staffDbContext)
        {
            _dbContext = staffDbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Staffs>> GetStaffs()
        {
            return _dbContext.Staffs;
        }

        [HttpGet("{staffId}")]
        public async Task<ActionResult<Staffs>> GetById(string staffId)
        {
            var staff = await _dbContext.Staffs.FindAsync(staffId);
            return staff;
        }

        [HttpPost]
        public async Task<ActionResult> Create(Staffs staff)
        {
            if ((await _dbContext.ShopInfo.FindAsync(staff.ShopId)) is null) return NotFound();
            await _dbContext.Staffs.AddAsync(staff);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update(Staffs staff)
        {
            _dbContext.Staffs.Update(staff);
            await _dbContext.SaveChangesAsync();
            return Ok();

        }

        [HttpDelete]
        public async Task<ActionResult> Delete(string staffId)
        {
            var staff = await _dbContext.Staffs.FindAsync(staffId);
            _dbContext.Staffs.Remove(staff);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
