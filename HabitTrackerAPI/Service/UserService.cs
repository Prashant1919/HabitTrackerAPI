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
        public async Task<List<RegisterUserDto>> GetAlluser()
        {
            var users = await _repository.GetALLUser();
            return users.Select(u => new RegisterUserDto
            {
                Id = u.Id,
                Name = u.Name,
                 Email= u.Email
            }).ToList();
        }

        public async Task<string> RegisterUserAsync(RegisterUserDto dto)
        {
            var existingUser = await _repository.GetUserByEmailAsync(dto.Id);
            if (existingUser != null) return "Email already registered.";

            // Hash the password
            using var sha256 = SHA256.Create();
            var hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(dto.Password));
            var passwordHash = System.Convert.ToBase64String(hashBytes);

            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                PasswordHash = passwordHash
            };

            await _repository.AddUser(user);
            return "User registered successfully.";
        }
    }
}
