namespace HabitTrackerAPI.repo
{
    public interface IHabit
    {
        Task<List<Model.Habit>> GetAllHabitAsync();
        Task<Model.Habit> GetHabitByIdAsync(int id);
        Task AddHabitAsync (Model.Habit habit);
        Task  DeleteHabitAsync (Model.Habit habit);
        Task UpdateHabitAsync (Model.Habit habit);
    }
}
