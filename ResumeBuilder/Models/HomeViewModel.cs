using ResumeBuilder.Controllers;

namespace ResumeBuilder.Models
{
    public class HomeViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public string Address { get; set; }
        public int Age { get; set; }

        public string Facebook { get; set; }
        public string LinkedIn { get; set; }
        public string Portfolio { get; set; }
        public string Github { get; set; }
        public string Objective { get; set; }

        public List<School1> Schools { get; set; }
        public List<Skill1> Skills { get; set; }
        public List<Training1> Trainings { get; set; }
        public List <EmergencyContact1> EmergencyContacts { get; set; }
        public List <Experience1> Experiences { get; set; }
    }
    public class Experience1
    {
        public int id { get; set; }
        public string ExperienceName { get; set; }
        public string ExperienceLocation { get; set; }
        public string Role { get; set; }

    }
    public class EmergencyContact1
    {
        public string EmergencyContact { get; set; }
        public string EmergencyNumber { get; set; }
        public string EmergencyRelation { get; set; }
    }
    public class Training1
    {
        public string TrainingName { get; set; }
        public string TrainingLocation { get; set; }
    }
    public class Skill1
    {
        public string SkillName { get; set; }
    }
    public class School1
    {
        public int id { get; set; }
        public string SchoolName { get; set; }
        public string Course { get; set; }
        public string SchoolLocation { get; set; }
        public DateTime StartDate { get; set; }
    }
}
