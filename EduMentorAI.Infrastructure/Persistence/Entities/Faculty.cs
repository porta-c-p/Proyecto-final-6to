using System;
using System.Collections.Generic;

namespace EduMentorAI.Infrastructure.Persistence.Entities;

public partial class Faculty
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Code { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<School> Schools { get; set; } = new List<School>();
}
