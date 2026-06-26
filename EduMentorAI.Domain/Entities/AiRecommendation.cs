using System;
using System.Collections.Generic;

namespace EduMentorAI.Domain.Entities;

public partial class AiRecommendation
{
    public int Id { get; set; }

    public int RiskPredictionId { get; set; }

    public string RecommendationText { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public virtual RiskPrediction RiskPrediction { get; set; } = null!;
}
