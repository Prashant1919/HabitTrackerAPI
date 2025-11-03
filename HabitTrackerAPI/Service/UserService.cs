using System.Text;
using HabitTrackerAPI.DTO;
using HabitTrackerAPI.Model;
using HabitTrackerAPI.repo;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Identity;
using System.Reflection.Metadata.Ecma335;

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
            var result=_repository.DeleteUserAsync(id);
            return result;
            
        }

        public async Task<List<RegisterUserDto>> GetAllUsersAsync()
        {
            var users= await _repository.GetAllUserAysnc();
            var result = users.Select(u => new RegisterUserDto
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email
            }).ToList();
            return result;

            
        }
            
        public async  Task<RegisterUserDto?> GetUserservice(int id)
        {
            var user = await _repository.GetUserByIdAysnc(id);

            if (user == null)
                return null;

            return new RegisterUserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                // map additional properties here
                // Example from Habits:
                Habit = user.Habits?
            .Select(h => new HabitDto
            {
                Id = h.Id,
                Description = h.Name
            }).ToList()

            };
        }

        public async Task<RegisterUserDto?> UpdateUserAsync(int id, CreateUserDtos dto)
        {
            var user = await _repository.GetUserByIdAysnc(id);
            if (user == null) return null;
            //Add more fields based on your create User
            user.Name = dto.Name;
            user.PasswordHash = dto.Password;
            user.Email = dto.Email;
            await _repository.UpdateUserAsync(user);
            return new RegisterUserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
                // Map other needed fields



            };
        }
        
    }
}
