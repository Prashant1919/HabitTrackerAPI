using HabitTrackerAPI.DTO;

namespace HabitTrackerAPI.Service
{
    public interface IHabitservice
    {
        Task<List<HabitDto>> GetAllHabitsAsync();
        Task<HabitDto?> GetHabitByIdAsync(int id);
        Task<HabitDto> AddHabitAsync(CreateHabitDto dto);
        Task<HabitDto?> UpdateHabitAsync(int id, CreateHabitDto dto);
        Task<bool> DeleteHabitAsync(int id);

    }
}
