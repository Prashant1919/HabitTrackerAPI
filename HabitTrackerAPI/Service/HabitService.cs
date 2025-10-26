using HabitTrackerAPI.DTO;
using HabitTrackerAPI.Model;
using HabitTrackerAPI.repo;
using Microsoft.IdentityModel.Tokens;

namespace HabitTrackerAPI.Service
{

    public class HabitService : IHabitservice
    {
        private readonly IHabit _habitRepository;

        public HabitService(IHabit repo)
        {
            _habitRepository = repo;
        }

        public async Task<HabitDto> AddHabitAsync(CreateHabitDto dto)
        {
            var entity = new Habit
            {
                Name = dto.Title,
                Frequency = dto.Description,
                UserId = dto.UserId
            };
            var created = await _habitRepository.AddHabitAsync(entity);
            return new HabitDto
            {
                Id = created.Id,
                Title = created.Name,
                Description = created.Frequency,
                UserId = created.UserId
            };
        }

        public async Task<bool> DeleteHabitAsync(int id)
        {
           return  await _habitRepository.DeleteHabitAsync(id);
             
        }

        public async Task<List<HabitDto>> GetAllHabitsAsync()
        {
            var habits = await _habitRepository.GetAllHabitAsync();
            return habits.Select(h => new HabitDto
            {
                Id = h.Id,
                Title = h.Name,
                Description = h.Frequency,
                UserId = h.UserId
            }).ToList();
        }

        public async  Task<HabitDto?> GetHabitByIdAsync(int id)
        {
            var habit = await _habitRepository.GetHabitByIdAsync(id);
            return habit == null ? null : new HabitDto
            {
                Id = habit.Id,
                Title = habit.Name,
                Description = habit.Frequency,
                UserId = habit.UserId
            };
        }

        public  async Task<HabitDto?> UpdateHabitAsync(int id, CreateHabitDto dto)
        {
            var existing = await _habitRepository.GetHabitByIdAsync(id);
            if (existing == null) return null;
            existing.Name = dto.Title;
            existing.Frequency = dto.Description;

            var updated = await _habitRepository.UpdateHabitAsync(existing);
            return updated == null ? null : new HabitDto
            {
                Id = updated.Id,
                Title = updated.Name,
                Description = updated.Frequency,
                UserId = updated.UserId
            };
        }
    }
}
