using System;
using System.Collections.Generic;

namespace ResumeBuilder.Models;

public partial class Skill
{
    public int Id { get; set; }

    public string? Skillname { get; set; }

    public int? StudentId { get; set; }

    public virtual Student? Student { get; set; }
}
