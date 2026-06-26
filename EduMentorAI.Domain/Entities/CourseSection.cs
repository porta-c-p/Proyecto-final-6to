using System;
using System.Collections.Generic;

namespace EduMentorAI.Domain.Entities;

public partial class CourseSection
{
    public int Id { get; set; }

    public int CourseId { get; set; }

    public int TeacherId { get; set; }

    public int AcademicPeriodId { get; set; }

    public string SectionName { get; set; } = null!;

    public int MaxStudents { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual AcademicPeriod AcademicPeriod { get; set; } = null!;

    public virtual Course Course { get; set; } = null!;

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    public virtual ICollection<Evaluation> Evaluations { get; set; } = new List<Evaluation>();

    public virtual ICollection<RiskPrediction> RiskPredictions { get; set; } = new List<RiskPrediction>();

    public virtual Teacher Teacher { get; set; } = null!;
}
