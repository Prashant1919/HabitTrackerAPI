namespace HabitTrackerAPI.Model
{
    public class Habit
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public string Frequency { get; set; }
        public DateTime CreatedAt { get; set; }= DateTime.Now;
        // foreign key 
        public int UserId { get; set; }
        //Navigation property
        public User? User { get; set; }
        //one Habit->Many logs
        public ICollection<HabitLog> HabitLogs { get; set; } =new List<HabitLog>();
    

    }
}
