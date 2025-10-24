using HabitTrackerAPI.DTO;
using HabitTrackerAPI.Model;
using HabitTrackerAPI.repo;
using Microsoft.IdentityModel.Tokens;

namespace HabitTrackerAPI.Service
{
    
    public class HabitService : IHabitservice
    {
        private readonly IHabit _habitRepository;
        private readonly IUserRepository _userRepository;
        public HabitService(IUserRepository userRepository, IHabit habitRepository)
        {
            _habitRepository=habitRepository;
            _userRepository=userRepository;
        }
        public async Task<string> AddHabitAsync(CreateHabitDto dto)
        {
            var user = await _userRepository.GetUserByEmailAsync(dto.UserId);
            if (user == null) return $"User with ID {dto.UserId} not found.";

            var habit = new Habit
            {
                Name = dto.Name,
                Frequency = dto.Frequency,
                UserId = dto.UserId,
                CreatedAt = DateTime.UtcNow
            };

            await _habitRepository.AddHabitAsync(habit);
            return "Habit added successfully.";


        }

        public async  Task<string> DeleteHabitAsync(int habitId)
        {
            var habit = await _habitRepository.GetHabitByIdAsync(habitId);
            if (habit == null) return $"Habit with ID {habitId} not found.";

            await _habitRepository.DeleteHabitAsync(habit);
            return "Habit deleted successfully.";
        }

        public async  Task<List<HabitDto>> GetAllHabitAsync()
        {
            var habit=await _habitRepository.GetAllHabitAsync();
            return habit.Select(h => new HabitDto
            {
                Id = h.Id,
                Name = h.Name,
                Frequency = h.Frequency,
                CreatedAt = h.CreatedAt,
                
                
            }).ToList();
        }

        public async Task<HabitDto> GetHabitAsync(HabitDto dto)
        {
            var habit=await _habitRepository.GetHabitByIdAsync(dto.Id);
            if (habit == null) return null;
            return new HabitDto
            {
                Id = habit.Id,
                Name = habit.Name,
                Frequency = habit.Frequency,
                CreatedAt = habit.CreatedAt,

            };
           
            
        }

        public async Task<string> updateHabitAsync(int id, UpdateHabitDto dto)
        {
            var habit = await _habitRepository.GetHabitByIdAsync(id);
            if (habit == null) return $"Habit with ID {id} not found.";

            habit.Name = dto.Name;
            habit.Frequency = dto.Frequency;

            await _habitRepository.UpdateHabitAsync(habit);
            return "Habit updated successfully.";

        }
    }
}
