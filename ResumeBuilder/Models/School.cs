using System;
using System.Collections.Generic;

namespace ResumeBuilder.Models;

public partial class School
{
    public int Id { get; set; }

    public string? Schoolname { get; set; }

    public string? Course { get; set; }

    public string? Location { get; set; }

    public int? StudentId { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public virtual Student? Student { get; set; }
}
