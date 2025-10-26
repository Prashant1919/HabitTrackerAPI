namespace HabitTrackerAPI.repo
{
    public interface IUserRepository
    {
        Task<List<Model.User>> GetAllUserAysnc();
        Task<Model.User?> GetUserByIdAysnc(int id);
        Task<Model.User> AddUserAysnc(Model.User user);
        Task<Model.User?>UpdateUserAsync(Model.User user);
        Task<bool> DeleteUserAsync(int id);


    }
}
