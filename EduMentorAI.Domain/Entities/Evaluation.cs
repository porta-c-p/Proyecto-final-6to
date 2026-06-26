using System;
using System.Collections.Generic;

namespace EduMentorAI.Domain.Entities;

public partial class Evaluation
{
    public int Id { get; set; }

    public int CourseSectionId { get; set; }

    public int EvaluationTypeId { get; set; }

    public string Title { get; set; } = null!;

    public DateOnly EvaluationDate { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual CourseSection CourseSection { get; set; } = null!;

    public virtual EvaluationType EvaluationType { get; set; } = null!;

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();
}
