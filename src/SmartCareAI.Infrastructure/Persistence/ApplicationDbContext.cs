using Microsoft.EntityFrameworkCore;
using SmartCareAI.Domain.Entities; // لازم السطر ده يكون كدة

namespace SmartCareAI.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Patient> Patients => Set<Patient>();
    public DbSet<Appointment> Appointments => Set<Appointment>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // هنا ممكن نحدد إعدادات إضافية للجداول لو حابين (Fluent API)
        modelBuilder.Entity<Patient>()
            .Property(p => p.PhoneNumber)
            .IsRequired()
            .HasMaxLength(20);

        modelBuilder.Entity<Appointment>()
            .HasOne(a => a.Patient)
            .WithMany(p => p.Appointments)
            .HasForeignKey(a => a.PatientId);
    }
}