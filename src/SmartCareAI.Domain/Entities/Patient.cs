namespace SmartCareAI.Domain.Entities;

public class Patient
{
    public Guid Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string? WhatsAppId { get; set; } // عشان نعرفه لما يكلم الـ AI
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    // المريض ممكن يكون عنده كذا حجز
    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}