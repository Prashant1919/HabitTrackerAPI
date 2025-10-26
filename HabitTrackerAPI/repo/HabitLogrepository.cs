using HabitTrackerAPI.Data;
using HabitTrackerAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace HabitTrackerAPI.repo
{
    public class HabitLogrepository : IHabitLog
    {
        private readonly AppDbContext _context;
        public HabitLogrepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<HabitLog> AddHabitLogAsync(HabitLog log)
        {
            await _context.HabitLogs.AddAsync(log);
            await _context.SaveChangesAsync();
            return log;

        }

        public async Task<bool> DeleteHabitLogAsync(int id)
        {
            var existing = await _context.HabitLogs.FindAsync(id);
            if (existing == null) return false;

            _context.HabitLogs.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<HabitLog>> GetAllLogsAsync()
        {
            return await _context.HabitLogs.Include(l => l.Habit)
                                   .ThenInclude(h => h.User)
                                   .ToListAsync();
        }

        public async Task<HabitLog?> GetLogByIdAsync(int id)
        {
            return await _context.HabitLogs.Include(l => l.Habit)
                            .ThenInclude(h => h.User)
                            .FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<HabitLog?> UpdateHabitLogAsync(HabitLog log)
        {
            var existing = await _context.HabitLogs.FindAsync(log.Id);
            if (existing == null) return null;

            _context.Entry(existing).CurrentValues.SetValues(log);
            await _context.SaveChangesAsync();
            return existing;
        }
    }
}
