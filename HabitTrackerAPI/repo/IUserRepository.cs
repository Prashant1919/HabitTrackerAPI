namespace HabitTrackerAPI.repo
{
    public interface IUserRepository
    {
        Task<Model.User>GetUserByEmailAsync(int userid);
        Task AddUser(Model.User user);
        Task<List<Model.User>> GetALLUser();

    }
}
