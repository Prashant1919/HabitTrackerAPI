﻿namespace HabitTrackerAPI.DTO
{
    public class CreateHabitDto
    {
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int UserId { get; set; }
    }
}
