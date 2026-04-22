namespace SmartCareAI.Domain.Entities;

public class Appointment
{
    public Guid Id { get; set; }
    public Guid PatientId { get; set; }
    public DateTime ScheduledDate { get; set; }
    public string SymptomsDescription { get; set; } = string.Empty;
    public string TriageUrgency { get; set; } = "Normal"; // Normal, Urgent, Emergency (بيحددها الـ AI)
    public bool IsSyncedWithLegacy { get; set; } = false;
    public string Status { get; set; } = "Pending"; // Pending, Confirmed, Cancelled
    
    public Patient Patient { get; set; } = null!;
}