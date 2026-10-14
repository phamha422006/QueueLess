
namespace QueueLess.Api.Models;

public class Appointment
{
    public int AppointmentId { get; set; }

    public int CustomerId { get; set; }

    public int ServiceId { get; set; }

    public int? StaffId { get; set; }

    public DateTime StartAt { get; set; }

    public DateTime EndAt { get; set; }

    public string Status { get; set; } = "Pending";

    public string? Notes { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public ApplicationUser Customer { get; set; } = null!;

    public ApplicationUser? Staff { get; set; }

    public Service Service { get; set; } = null!;
}
