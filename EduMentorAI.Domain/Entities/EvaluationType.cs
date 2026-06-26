using System;
using System.Collections.Generic;

namespace EduMentorAI.Domain.Entities;

public partial class EvaluationType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Weight { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<Evaluation> Evaluations { get; set; } = new List<Evaluation>();
}
