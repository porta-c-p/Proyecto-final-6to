using System;
using System.Collections.Generic;

namespace EduMentorAI.Domain.Entities;

public partial class School
{
    public int Id { get; set; }

    public int FacultyId { get; set; }

    public string Name { get; set; } = null!;

    public string Code { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual Faculty Faculty { get; set; } = null!;

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
