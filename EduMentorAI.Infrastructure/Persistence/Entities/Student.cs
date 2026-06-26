using System;
using System.Collections.Generic;

namespace EduMentorAI.Infrastructure.Persistence.Entities;

public partial class Student
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int SchoolId { get; set; }

    public string StudentCode { get; set; } = null!;

    public int AdmissionYear { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    public virtual ICollection<RiskPrediction> RiskPredictions { get; set; } = new List<RiskPrediction>();

    public virtual School School { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
