using HabitTrackerAPI.DTO;

namespace HabitTrackerAPI.Service
{
    public interface IUserService
    {
        Task<List<RegisterUserDto>> GetAllUsersAsync();
        Task<RegisterUserDto?> GetUserservice(int id);
        Task<RegisterUserDto> AddUserAsync(CreateUserDtos dto);
        Task<RegisterUserDto?> UpdateUserAsync(int id, CreateUserDtos dto);
        Task<bool> DeleteUserAsync(int id);
    }
}
