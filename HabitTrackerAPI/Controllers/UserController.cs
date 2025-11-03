using HabitTrackerAPI.Data;
using HabitTrackerAPI.DTO;
using HabitTrackerAPI.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HabitTrackerAPI.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userservice;

        public UserController(IUserService userservice) { 
            _userservice = userservice;
        }
      
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CreateUserDtos dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userservice.AddUserAsync(dto);
            return Ok(user);
        }
       
        [HttpGet("all")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userservice.GetAllUsersAsync();
            return Ok(users);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userservice.GetUserservice(id);
            if (user == null)
                return NotFound($"User with ID {id} not found.");
            return Ok(user);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] CreateUserDtos dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _userservice.UpdateUserAsync(id, dto);
            if (updated == null)
                return NotFound($"User with ID {id} not found.");

            return Ok(updated);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var success = await _userservice.DeleteUserAsync(id);
            if (!success)
                return NotFound($"User with ID {id} not found.");
            return Ok("User deleted successfully.");
        }



    }
}
