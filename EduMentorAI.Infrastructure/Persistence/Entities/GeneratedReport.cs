using System;
using System.Collections.Generic;

namespace EduMentorAI.Infrastructure.Persistence.Entities;

public partial class GeneratedReport
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string ReportName { get; set; } = null!;

    public string ReportType { get; set; } = null!;

    public string FilePath { get; set; } = null!;

    public DateTime GeneratedAt { get; set; }

    public virtual User User { get; set; } = null!;
}
