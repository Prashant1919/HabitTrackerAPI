using HabitTrackerAPI.Data;
using HabitTrackerAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace HabitTrackerAPI.repo
{
    public class UserRepository :IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> AddUserAysnc(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var existing = await _context.Users.FindAsync(id);
            if (existing == null) return false;
             _context.Users.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<User>> GetAllUserAysnc()
        {
            return await _context.Users.Include(u => u.Habits).ToListAsync();
                
            
        }

        public async Task<User?> GetUserByIdAysnc(int id)
        {
             return await _context.Users.Include(u=>u.Habits)
                .ThenInclude(h=>h.HabitLogs)
                .FirstOrDefaultAsync(u=>u.Id==id);
        }

        public async Task<User?> UpdateUserAsync(User user)
        {
            var existing = await _context.Users.FindAsync(user.Id);
            if (existing != null) return null;
            _context.Entry(user).CurrentValues.SetValues(existing);
            await _context.SaveChangesAsync();
            return existing;
        }
    }


}
