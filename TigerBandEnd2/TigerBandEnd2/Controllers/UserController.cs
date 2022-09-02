using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TigerBandEnd2.Data;
using TigerBandEnd2.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TigerBandEnd2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly PhoneDbContext _context;

        public UserController(PhoneDbContext context)
        {
            _context = context;
        }
    
        // GET: api/<UserController>
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<UserController>>> GetUsers()
        //{
        //    if (_context.Users == null)
        //    {
        //        return NotFound();
        //    }
        //    return await _context.Users.ToListAsync();
        //}

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<UserController>>> Get(int userId)
        {
            var users = await _context.Users
                //.Where(u => u.UserId == userId)
                .Include(u => u.Device)
                .Include(u => u.Plans)
                .ToListAsync();
            //return users;
            return Ok(User);
        }

        [HttpPost]
        public async Task<ActionResult<List<User>>> Create(CreateUserDto request)
        {
            var user = await _context.Users.FindAsync(request.UserId);
            if (user == null)
                return NotFound();

            var newUser = new User
            {
                Name = request.UserName,
                Email = request.Email,
                //UserId = user
            };

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            //return await Get(newUser.UserId);
            return CreatedAtAction("Get", new { id = user.Id }, user);
        }

        [HttpPost("device")]
        public async Task<ActionResult<User>> AddWeapon(AddDeviceDto request)
        {
            var user = await _context.Users.FindAsync(request.UserId);
            if (user == null)
                return NotFound();

            var newDevice = new Device
            {
                Type = request.Type,
                Model = request.Model,
                DevicePrice = request.DevicePrice,
                User = user
            };

            _context.Devices.Add(newDevice);
            await _context.SaveChangesAsync();

            return user;
        }

        [HttpPost("skill")]
        public async Task<ActionResult<User>> AddCharacterSkill(AddUserPlanDto request)
        {
            var user = await _context.Users
                .Where(u => u.Id == request.UserId)
                .Include(u => u.Plans)
                .FirstOrDefaultAsync();
            if (user == null)
                return NotFound();

            var plan = await _context.Plans.FindAsync(request.PlanId);
            if (plan == null)
                return NotFound();

            user.Plans.Add(plan);
            await _context.SaveChangesAsync();

            return user;
        }


        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
