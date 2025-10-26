using System.Text;
using HabitTrackerAPI.DTO;
using HabitTrackerAPI.Model;
using HabitTrackerAPI.repo;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace HabitTrackerAPI.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
       public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public  async Task<RegisterUserDto> AddUserAsync(CreateUserDtos dto)
        {
            var entity = new User
            {
                Email = dto.Email,
                Name = dto.Name,
                PasswordHash = dto.Password // hash later in service
            };
            var created = await _repository.AddUserAysnc(entity);
            return new RegisterUserDto
            {
                Id = created.Id,
                Email = created.Email,
                Name = created.Name

            };
        }

        public Task<bool> DeleteUserAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<RegisterUserDto>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<RegisterUserDto?> GetUserByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<RegisterUserDto?> UpdateUserAsync(int id, CreateUserDtos dto)
        {
            throw new NotImplementedException();
        }
    }
}
