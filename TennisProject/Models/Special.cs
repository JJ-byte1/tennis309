using System;
using System.Collections.Generic;

namespace TennisProject.Models;

public partial class Special
{
    public string? UserId { get; set; }

    public DateTime? Date { get; set; }

    public string? SpecialDescription { get; set; }
}
