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
        public async Task<User> GetUserByEmailAsync(int userid)
        {
          var data= await _context.Users.FirstOrDefaultAsync(u=>u.Id == userid);
            return data;

        }

       public  async Task AddUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

        }

        public async Task<List<User>> GetALLUser()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
