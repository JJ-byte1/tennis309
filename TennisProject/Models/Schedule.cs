using System;
using System.Collections.Generic;

namespace TennisProject.Models;

public partial class Schedule
{
    public Guid SessionId { get; set; }

    public string? UserId { get; set; }

    public string? ScheduleItem { get; set; }

    public DateTime? Date { get; set; }
}
