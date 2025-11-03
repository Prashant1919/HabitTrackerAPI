using HabitTrackerAPI.Data;
using HabitTrackerAPI.DTO;
using HabitTrackerAPI.Model;
using HabitTrackerAPI.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HabitTrackerAPI.Controllers
{
    [ApiController]
    [Route("api/habitslogs")]
    public class HabitLogController : ControllerBase
    {
        private readonly IHabitLogsService _habitLogService;

        public HabitLogController(IHabitLogsService habitLogService) {
            _habitLogService = habitLogService;
        }
        
        [HttpPost]
        public async Task<IActionResult> AddHabitLog([FromBody] CreateHabitLogDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var log = await _habitLogService.AddHabitLogAsync(dto);
            return Ok(log);
        }
        [HttpGet("all")]
        public async Task<IActionResult> GetAllLogs()
        {
            var logs = await _habitLogService.GetAllLogsAsync();
            return Ok(logs);

        }
       
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLogById(int id)
        {
            var log = await _habitLogService.GetLogByIdAsync(id);
            if (log == null)
                return NotFound($"Habit Log with ID {id} not found.");
            return Ok(log);
        }
     
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHabitLog(int id, [FromBody] CreateHabitLogDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _habitLogService.UpdateHabitLogAsync(id, dto);
            if (updated == null)
                return NotFound($"Habit Log with ID {id} not found.");

            return Ok(updated);
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHabitLog(int id)
        {
            var success = await _habitLogService.DeleteHabitLogAsync(id);
            if (!success)
                return NotFound($"Habit Log with ID {id} not found.");

            return Ok("Habit Log deleted successfully.");
        }

    }
}
