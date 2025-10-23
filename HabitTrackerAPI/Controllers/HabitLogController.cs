using HabitTrackerAPI.Data;
using HabitTrackerAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HabitTrackerAPI.Controllers
{
    [ApiController]
    [Route("api/habitslogs")]
    public class HabitLogController : ControllerBase
    {
        private readonly AppDbContext _context;
        public HabitLogController(AppDbContext context) { }
        //Get All Logs
        [HttpGet("all")]
        public async Task<IActionResult> GetAlllog()
        {
            var data = await _context.HabitLogs.Include(h => h.Habit).ToListAsync();
            return Ok(data);

        }
        [HttpGet("habit/{habitId}")]
        public async Task<IActionResult> GetLogsHabit(int habitId) {
            var log = await _context.HabitLogs.Where(l => l.Habitid == habitId).ToListAsync();
            return Ok(log);
        }
        [HttpPost("Habitlog")]
        public async Task<IActionResult> AddLogs(HabitLog log)
        {
            var habit = await _context.Habits.FindAsync(log.Habitid);
            if (habit == null)
                return NotFound($"Habit with ID {log.Habitid} not found.");

            // Only link HabitId, do not set log.Habit manually
            log.Habit = null;

            _context.HabitLogs.Add(log);
            await _context.SaveChangesAsync();

            return Ok(log);

        }
        //Update HabitLog
        [HttpPut("{id}")]
        public async Task<IActionResult> updateLog(int id, HabitLog log)
        {
            var existing = await _context.HabitLogs.FindAsync(id);

            if (existing != null) return NotFound();
            existing.IsCompleted = log.IsCompleted;
            await _context.SaveChangesAsync();
            return Ok(existing);
        }
        //Delete HabitLog
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLog(int id)
        {
            var log = await _context.HabitLogs.FindAsync(id);
            if(log==null) return NotFound();
            _context.HabitLogs.Remove(log);
            await _context.SaveChangesAsync();
            return Ok(log);

        }
    }
}
