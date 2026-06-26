using System;
using System.Collections.Generic;

namespace EduMentorAI.Infrastructure.Persistence.Entities;

public partial class Course
{
    public int Id { get; set; }

    public int SchoolId { get; set; }

    public string Name { get; set; } = null!;

    public string Code { get; set; } = null!;

    public int Credits { get; set; }

    public int Cycle { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<CourseSection> CourseSections { get; set; } = new List<CourseSection>();

    public virtual School School { get; set; } = null!;
}
