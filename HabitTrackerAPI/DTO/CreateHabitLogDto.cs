namespace HabitTrackerAPI.DTO
{
    public class CreateHabitLogDto
    {
        public int HabitId { get; set; }
        public DateTime Date { get; set; }
        public bool IsCompleted { get; set; }
    }
}
