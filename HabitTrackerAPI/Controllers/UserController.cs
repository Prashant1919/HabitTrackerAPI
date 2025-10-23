using HabitTrackerAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HabitTrackerAPI.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;
        public UserController(AppDbContext context) { 
            _context = context;
        }
        [HttpPost("register")]
        public async Task<IActionResult>Resgister([FromBody] Model.User user)
        {
            if (user == null)
                return BadRequest("User data is required.");

            // Optional: Check if email already exists
            var existingUser = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == user.Email);
            if (existingUser != null)
                return BadRequest("Email already registered.");

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok(user);

        }
        [HttpGet("all")]
        public async Task<IActionResult> GetUsers()
        {
           var data= await _context.Users.ToListAsync();
            return Ok(data);
        }


       
    }
}
