using System.ComponentModel.DataAnnotations;

namespace QueueLess.Api.Models;

public class StaffSchedule
{
    [Key]
    public int ScheduleId { get; set; }

    public int StaffId { get; set; }

    // 0 = Sunday, 1 = Monday, ..., 6 = Saturday
    public byte DayOfWeek { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public bool IsActive { get; set; } = true;
}