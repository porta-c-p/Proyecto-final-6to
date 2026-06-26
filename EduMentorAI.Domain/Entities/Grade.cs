using System;
using System.Collections.Generic;

namespace EduMentorAI.Domain.Entities;

public partial class Grade
{
    public int Id { get; set; }

    public int EnrollmentId { get; set; }

    public int EvaluationId { get; set; }

    public decimal Score { get; set; }

    public DateTime RegisteredAt { get; set; }

    public virtual Enrollment Enrollment { get; set; } = null!;

    public virtual Evaluation Evaluation { get; set; } = null!;
}
