namespace HabitTrackerAPI.DTO
{
    public class UpdateHabitDto
    {
        public string Name { get; set; } = string.Empty;

        // Updated frequency of the habit (e.g., Daily, Weekly)
        public string Frequency { get; set; } = string.Empty;
    }
}
