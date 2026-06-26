using System;
using System.Collections.Generic;

namespace EduMentorAI.Domain.Entities;

public partial class Attendance
{
    public int Id { get; set; }

    public int EnrollmentId { get; set; }

    public DateOnly AttendanceDate { get; set; }

    public string Status { get; set; } = null!;

    public string? Observation { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Enrollment Enrollment { get; set; } = null!;
}
