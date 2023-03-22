using System;
using System.Collections.Generic;

namespace ResumeBuilder.Models;

public partial class Student
{
    public int Id { get; set; }

    public string? Firstname { get; set; }

    public string? Middlename { get; set; }

    public string? Lastname { get; set; }

    public int? Age { get; set; }

    public string? Address { get; set; }

    public string? Email { get; set; }

    public string? Objectives { get; set; }

    public string? PhoneNumber { get; set; }

    public virtual ICollection<EmergencyContact> EmergencyContacts { get; } = new List<EmergencyContact>();

    public virtual ICollection<Experience> Experiences { get; } = new List<Experience>();

    public virtual ICollection<Link> Links { get; } = new List<Link>();

    public virtual ICollection<School> Schools { get; } = new List<School>();

    public virtual ICollection<Skill> Skills { get; } = new List<Skill>();

    public virtual ICollection<Training> Training { get; } = new List<Training>();
}
