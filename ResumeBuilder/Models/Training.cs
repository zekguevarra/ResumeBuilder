using System;
using System.Collections.Generic;

namespace ResumeBuilder.Models;

public partial class Training
{
    public int Id { get; set; }

    public string? TrainingName { get; set; }

    public string? Location { get; set; }

    public int? StudentId { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public virtual Student? Student { get; set; }
}
