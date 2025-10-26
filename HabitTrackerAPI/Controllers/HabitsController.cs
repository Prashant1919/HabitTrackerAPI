using HabitTrackerAPI.Data;
using HabitTrackerAPI.DTO;
using HabitTrackerAPI.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HabitTrackerAPI.Controllers
{
    [ApiController]
    [Route("api/habits")]

    public class HabitsController : ControllerBase
    {
        private readonly IHabitservice _habitservice;
       
        public HabitsController(IHabitservice service)
        {
            _habitservice = service;
        }
       
        [HttpPost]
        public async Task<IActionResult> AddHabit([FromBody] CreateHabitDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var habit = await _habitservice.AddHabitAsync(dto);
            return Ok(habit);
        }
        
        [HttpGet("all")]
        public async Task<IActionResult> GetAllHabits()
        {
            var habits = await _habitservice.GetAllHabitsAsync();
            return Ok(habits);
        }
       
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHabitById(int id)
        {
            var habit = await _habitservice.GetHabitByIdAsync(id);
            if (habit == null)
                return NotFound($"Habit with ID {id} not found.");
            return Ok(habit);
        }
     
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHabit(int id, [FromBody] CreateHabitDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _habitservice.UpdateHabitAsync(id, dto);
            if (updated == null)
                return NotFound($"Habit with ID {id} not found.");

            return Ok(updated);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHabit(int id)
        {
            var success = await _habitservice.DeleteHabitAsync(id);
            if (!success)
                return NotFound($"Habit with ID {id} not found.");

            return Ok("Habit deleted successfully.");
        }



    }
}
