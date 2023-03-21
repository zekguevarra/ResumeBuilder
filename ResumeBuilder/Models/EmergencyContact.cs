using System;
using System.Collections.Generic;

namespace ResumeBuilder.Models;

public partial class EmergencyContact
{
    public int Id { get; set; }

    public string? EmergencyName { get; set; }

    public string? EmergencyContact1 { get; set; }

    public string? Relationship { get; set; }

    public int? StudentId { get; set; }

    public virtual Student? Student { get; set; }
}
