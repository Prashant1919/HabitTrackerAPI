namespace HabitTrackerAPI.Model
{
    public class HabitLog
    {
        public int Id { get; set; }
        public int Habitid {  get; set; }
        public DateTime Date {  get; set; }
        public bool IsCompleted { get; set; }
        public Habit Habit { get; set; }

    }
}
