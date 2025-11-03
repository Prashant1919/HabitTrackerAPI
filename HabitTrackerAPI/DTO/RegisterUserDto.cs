namespace HabitTrackerAPI.DTO
{
    public class RegisterUserDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public List<HabitDto>? Habit { get; set; } // 

    }
}
