using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QueueLess.Api.Models;

namespace QueueLess.Api.Data;

public class AppDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Service> Services => Set<Service>();

    public DbSet<StaffSchedule> StaffSchedules => Set<StaffSchedule>();

    public DbSet<Appointment> Appointments => Set<Appointment>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // ApplicationUser
        builder.Entity<ApplicationUser>(entity =>
        {
            entity.Property(u => u.FullName)
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(u => u.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()");
        });

        // Service
        builder.Entity<Service>(entity =>
        {
            entity.Property(s => s.Name)
                .HasMaxLength(150)
                .IsRequired();

            entity.Property(s => s.Description)
                .HasMaxLength(500);

            entity.ToTable(t => t.HasCheckConstraint(
                "CK_Services_DurationMinutes",
                "[DurationMinutes] > 0"));

            entity.HasIndex(s => s.Name);
        });

        // StaffSchedule
        builder.Entity<StaffSchedule>(entity =>
        {
            entity.ToTable(t =>
            {
                t.HasCheckConstraint(
                    "CK_StaffSchedules_DayOfWeek",
                    "[DayOfWeek] BETWEEN 0 AND 6");

                t.HasCheckConstraint(
                    "CK_StaffSchedules_WorkingHours",
                    "[EndTime] > [StartTime]");
            });

            entity.HasOne<ApplicationUser>()
                .WithMany()
                .HasForeignKey(s => s.StaffId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasIndex(s => new { s.StaffId, s.DayOfWeek });
        });

        // Appointment
        builder.Entity<Appointment>(entity =>
        {
            entity.Property(a => a.Status)
                .HasMaxLength(20)
                .IsRequired();

            entity.Property(a => a.Notes)
                .HasMaxLength(500);

            entity.ToTable(t => t.HasCheckConstraint(
                "CK_Appointments_TimeRange",
                "[EndAt] > [StartAt]"));

            entity.HasOne(a => a.Customer)
                .WithMany()
                .HasForeignKey(a => a.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(a => a.Staff)
                .WithMany()
                .HasForeignKey(a => a.StaffId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(a => a.Service)
                .WithMany(s => s.Appointments)
                .HasForeignKey(a => a.ServiceId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasIndex(a => new { a.StaffId, a.StartAt, a.EndAt });
            entity.HasIndex(a => new { a.CustomerId, a.StartAt });
        });
    }
}