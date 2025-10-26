namespace HabitTrackerAPI.repo
{
    public interface IHabit
    {
        Task<List<Model.Habit>> GetAllHabitAsync();
        Task<Model.Habit?> GetHabitByIdAsync(int id);
        Task<Model.Habit> AddHabitAsync (Model.Habit habit);
        Task<bool> DeleteHabitAsync (int id);
        Task<Model.Habit?> UpdateHabitAsync (Model.Habit habit);
    }
}
