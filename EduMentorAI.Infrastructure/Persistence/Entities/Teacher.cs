using System;
using System.Collections.Generic;

namespace EduMentorAI.Infrastructure.Persistence.Entities;

public partial class Teacher
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string TeacherCode { get; set; } = null!;

    public string? Specialty { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<CourseSection> CourseSections { get; set; } = new List<CourseSection>();

    public virtual User User { get; set; } = null!;
}
