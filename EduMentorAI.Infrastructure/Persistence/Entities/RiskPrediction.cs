using System;
using System.Collections.Generic;

namespace EduMentorAI.Infrastructure.Persistence.Entities;

public partial class RiskPrediction
{
    public int Id { get; set; }

    public int StudentId { get; set; }

    public int CourseSectionId { get; set; }

    public string RiskLevel { get; set; } = null!;

    public decimal RiskScore { get; set; }

    public string? PredictionSummary { get; set; }

    public DateTime GeneratedAt { get; set; }

    public virtual ICollection<AiRecommendation> AiRecommendations { get; set; } = new List<AiRecommendation>();

    public virtual CourseSection CourseSection { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
