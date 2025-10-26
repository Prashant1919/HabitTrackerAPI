namespace HabitTrackerAPI.DTO
{
    public class HabitLogDto
    {
        public int Id { get; set; }
        public int Habitid { get; set; }
        public DateTime Date { get; set; }
        public bool IsCompleted { get; set; }
    }
}
