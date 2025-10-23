using HabitTrackerAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HabitTrackerAPI.Controllers
{
    [ApiController]
    [Route("api/habits")]

    public class HabitsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public HabitsController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet("allhabits")]
        public async Task<IActionResult> GetHabits()
        {
           var data= await _context.Habits.Include(h=>h.User).ToListAsync();
            return Ok(data);
        }
       
        [HttpPost]
        public async Task<IActionResult> AddHabit([FromBody] Model.Habit habit)
        {
            var user = await _context.Users.FindAsync(habit.Id);
            if (user == null)
                return NotFound($"User with ID {habit.Id} not found.");

            _context.Habits.Add(habit);
            await _context.SaveChangesAsync();
            return Ok(habit);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHabit(int id,Model.Habit habit)
        {
            var existing = await _context.Habits.FindAsync(id);
            if (existing != null) return NotFound();
            existing.Name=habit.Name;
            existing.Frequency=habit.Frequency;
            await _context.SaveChangesAsync();
            return Ok(existing);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHabit(int id)
        {
            var habit = await _context.Habits.FindAsync(id);
            if (habit == null) return NotFound();
             _context.Habits.Remove(habit);
            await _context.SaveChangesAsync();
            return Ok(habit);


        }



    }
}
