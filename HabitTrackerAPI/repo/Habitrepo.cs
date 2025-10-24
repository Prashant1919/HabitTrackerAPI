using HabitTrackerAPI.Data;
using HabitTrackerAPI.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace HabitTrackerAPI.repo
{
    public class Habitrepo : IHabit
    {
        private readonly AppDbContext _context;
       public Habitrepo(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddHabitAsync(Habit habit)
        {
            await _context.Habits.AddAsync(habit);
            await _context.SaveChangesAsync();
        }

        public async Task  DeleteHabitAsync(Habit habit)
        {
            _context.Habits.Remove(habit);
            await _context.SaveChangesAsync();
            
        }

        public async Task<List<Habit>> GetAllHabitAsync()
        {
            var data = await _context.Habits.Include(h => h.User).ToListAsync();
            return data;
        }

        public async Task<Habit> GetHabitByIdAsync(int id)
        {
              return await _context.Habits
              .Include(h => h.User)
              .FirstOrDefaultAsync(h => h.Id == id);
        }

        public async Task UpdateHabitAsync(Habit habit)
        {
            _context.Habits.Update(habit);
             await _context.SaveChangesAsync();
        }
    }
}
