
namespace QueueLess.Api.Models;

public class Service
{
    public int ServiceId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public int DurationMinutes { get; set; }

    public bool IsActive { get; set; } = true;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<Appointment> Appointments { get; set; }
        = new List<Appointment>();
}
