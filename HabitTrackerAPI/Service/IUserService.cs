using HabitTrackerAPI.DTO;

namespace HabitTrackerAPI.Service
{
    public interface IUserService
    {
        Task<string> RegisterUserAsync (RegisterUserDto dto);
        Task<List<RegisterUserDto>> GetAlluser();


    }
}
