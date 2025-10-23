namespace HabitTrackerAPI.Model
{
    public class Habit
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public string Frequency { get; set; }
        public DateTime CreatedAt { get; set; }
        public User User { get; set; }
        public ICollection<HabitLog>HabitLogs=new List<HabitLog>();

    }
}
