using HabitTrackerAPI.Model;

namespace HabitTrackerAPI.repo
{
    public interface IHabitLog
    {
        Task<List<HabitLog>> GetAllLogsAsync();
        Task<HabitLog?> GetLogByIdAsync(int id );
        Task<HabitLog> AddHabitLogAsync(HabitLog log);
        Task<HabitLog?> UpdateHabitLogAsync(HabitLog log);
        Task<bool> DeleteHabitLogAsync(int id);
    }
}
