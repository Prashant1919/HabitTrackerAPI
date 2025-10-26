namespace HabitTrackerAPI.Model
{
    public class HabitLog
    {
        public int Id { get; set; }
        //foreign key
        public int Habitid {  get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public bool IsCompleted { get; set; }
        public Habit? Habit { get; set; } 

    }
}
