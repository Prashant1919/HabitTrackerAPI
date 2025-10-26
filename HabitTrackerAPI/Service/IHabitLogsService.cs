using HabitTrackerAPI.DTO;

namespace HabitTrackerAPI.Service
{
    public interface IHabitLogsService
    {
        Task<List<HabitLogDto>> GetAllLogsAsync();
        Task<HabitLogDto?> GetLogByIdAsync(int id);
        Task<HabitLogDto> AddHabitLogAsync(CreateHabitLogDto dto);
        Task<HabitLogDto?> UpdateHabitLogAsync(int id, CreateHabitLogDto dto);
        Task<bool> DeleteHabitLogAsync(int id);


    }
}
