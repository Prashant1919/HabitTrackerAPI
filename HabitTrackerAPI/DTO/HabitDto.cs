using HabitTrackerAPI.Model;

namespace HabitTrackerAPI.DTO
{
    public class HabitDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int UserId { get; set; }

    }
}
