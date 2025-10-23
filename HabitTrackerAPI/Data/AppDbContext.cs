using HabitTrackerAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace HabitTrackerAPI.Data
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> Users {  get; set; }
        public DbSet<Habit>Habits { get; set; }
        public DbSet<HabitLog>HabitLogs { get; set; }


        protected AppDbContext()
        {
        }
    }
}
