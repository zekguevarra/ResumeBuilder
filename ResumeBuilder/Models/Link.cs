using System;
using System.Collections.Generic;

namespace ResumeBuilder.Models;

public partial class Link
{
    public int LinkId { get; set; }

    public string? Facebook { get; set; }

    public string? LinkedIn { get; set; }

    public string? Github { get; set; }

    public string? Portfolio { get; set; }

    public int? StudentId { get; set; }

    public virtual Student? Student { get; set; }
}
