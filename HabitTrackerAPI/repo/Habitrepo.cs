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

        public async  Task<Habit> AddHabitAsync(Habit habit)
        {
            await _context.Habits.AddAsync(habit);
            await _context.SaveChangesAsync();
            return habit;
        }

        public async Task<bool> DeleteHabitAsync(int id)
        {
            var existing=await _context.Habits.FindAsync(id);
            if (existing == null) return false;
            _context.Habits.Remove(existing);
            await _context.SaveChangesAsync();
            return true;

            
        }

        public async Task<List<Habit>> GetAllHabitAsync()
        {
           return  await _context.Habits.Include(h => h.User)
                 .Include(h => h.HabitLogs)
                 .ToListAsync();    
        }

        public async Task<Habit?> GetHabitByIdAsync(int id)
        {
            return await _context.Habits.Include(h => h.User)
              .Include(h => h.HabitLogs)
              .FirstOrDefaultAsync(h => h.Id == id);
        }

        public async Task<Habit?> UpdateHabitAsync(Habit habit)
        {
            var existing = await _context.Habits.FindAsync(habit.Id);
            if (existing == null) return null;
            _context.Entry(existing).CurrentValues.SetValues(habit);
            await _context.SaveChangesAsync();
            return existing;
        }
    }
}
