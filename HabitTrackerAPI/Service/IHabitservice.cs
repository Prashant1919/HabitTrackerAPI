using HabitTrackerAPI.DTO;

namespace HabitTrackerAPI.Service
{
    public interface IHabitservice
    {
        Task<List<HabitDto>> GetAllHabitAsync();
        Task<HabitDto?> GetHabitAsync(HabitDto dto);
        Task<string> AddHabitAsync(CreateHabitDto dto);
        Task<string> DeleteHabitAsync(int id);
        Task<string>updateHabitAsync(int id , UpdateHabitDto dto);

    }
}
