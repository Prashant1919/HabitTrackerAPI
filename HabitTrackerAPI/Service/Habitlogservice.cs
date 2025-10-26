using HabitTrackerAPI.DTO;
using HabitTrackerAPI.Model;
using HabitTrackerAPI.repo;

namespace HabitTrackerAPI.Service
{
    public class Habitlogservice : IHabitLogsService
    {
        private readonly IHabitLog _habitrepo;
        public Habitlogservice(IHabitLog habitrepo)
        {
            _habitrepo = habitrepo;
        }

        public async Task<HabitLogDto> AddHabitLogAsync(CreateHabitLogDto dto)
        {
            var entity = new HabitLog
            {
                Habitid = dto.HabitId,
                Date = dto.Date,
                IsCompleted = dto.IsCompleted
            };
            var created = await _habitrepo.AddHabitLogAsync(entity);
            return new HabitLogDto
            {
                Id = created.Id,
                Habitid = created.Habitid,
                Date = created.Date,
                IsCompleted = created.IsCompleted
            };
        }

        public async Task<bool> DeleteHabitLogAsync(int id)
        {
            return await _habitrepo.DeleteHabitLogAsync(id);
        }

        public async Task<List<HabitLogDto>> GetAllLogsAsync()
        {
            var logs = await _habitrepo.GetAllLogsAsync();
            return logs.Select(l => new HabitLogDto
            {
                Id = l.Id,
                Habitid = l.Habitid,
                Date = l.Date,
                IsCompleted = l.IsCompleted
            }).ToList();
        }

        public async Task<HabitLogDto?> GetLogByIdAsync(int id)
        {
            var log = await _habitrepo.GetLogByIdAsync(id);
            return log == null ? null : new HabitLogDto
            {
                Id = log.Id,
                Habitid = log.Habitid,
                Date = log.Date,
                IsCompleted = log.IsCompleted
            };
        }

        public async Task<HabitLogDto?> UpdateHabitLogAsync(int id, CreateHabitLogDto dto)
        {
            var existing = await _habitrepo.GetLogByIdAsync(id);
            if (existing == null) return null;

            existing.Habitid = dto.HabitId;
            existing.Date = dto.Date;
            existing.IsCompleted = dto.IsCompleted;

            var updated = await _habitrepo.UpdateHabitLogAsync(existing);
            return updated == null ? null : new HabitLogDto
            {
                Id = updated.Id,
                Habitid = updated.Habitid,
                Date = updated.Date,
                IsCompleted = updated.IsCompleted
            };
        }
    }
}
