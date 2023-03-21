using System;
using System.Collections.Generic;

namespace ResumeBuilder.Models;

public partial class Experience
{
    public int Id { get; set; }

    public string? ExperienceName { get; set; }

    public string? Role { get; set; }

    public string? Location { get; set; }

    public int? StudentId { get; set; }

    public virtual Student? Student { get; set; }
}
