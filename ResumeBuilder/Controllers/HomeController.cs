using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using ResumeBuilder.Models;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.Intrinsics.X86;

namespace ResumeBuilder.Controllers
{
    public class HomeController : Controller
    {
        private readonly TupContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, TupContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ResumePreview()
        {
            var student = _context.Students.FirstOrDefault();
            var vm = new HomeViewModel()
            {
                FirstName = student.Firstname,
                MiddleName = student.Middlename,
                LastName = student.Lastname,
                Email = student.Email,
                Age = (int)student.Age,
                Address = student.Address,
                Objective = student.Objectives
            };
            var links = _context.Links.FirstOrDefault();
            vm.Github = links.Github;
            vm.Facebook = links.Facebook;
            vm.Portfolio = links.Portfolio;
            vm.LinkedIn = links.LinkedIn;


            var skilllist = _context.Skills.Where(x => x.StudentId == student.Id).ToList();
            vm.Skills = new List<Skill1>();
            foreach(var skill in skilllist)
            {
                vm.Skills.Add(new Skill1 { SkillName = skill.Skillname });
            }
            var traininglist = _context.Training.Where(x => x.StudentId == student.Id).ToList();
            vm.Trainings = new List<Training1>();
            foreach (var i in traininglist)
            {
                var tr = new Training1
                {
                    TrainingName=i.TrainingName,
                    TrainingLocation=i.Location
                    //StartDate=(DateTime)school.StartDate.GetValueOrDefault(),
                };
                vm.Trainings.Add(tr);
            }

            var emergencylist = _context.EmergencyContacts.Where(x => x.StudentId == student.Id).ToList();
            vm.EmergencyContacts = new List<EmergencyContact1>();
            foreach (var emergency in emergencylist)
            {
                vm.EmergencyContacts.Add(new EmergencyContact1 { EmergencyContact = emergency.EmergencyName });
                vm.EmergencyContacts.Add(new EmergencyContact1 { EmergencyNumber = emergency.EmergencyContact1 });
                vm.EmergencyContacts.Add(new EmergencyContact1 { EmergencyRelation = emergency.Relationship });
            }
            var schoollist=_context.Schools.Where(x=>x.StudentId==student.Id).ToList();
            vm.Schools = new List<School1>();
            foreach (var school in schoollist)
            {
                var ed = new School1
                {
                    id = school.Id,
                    SchoolName = school.Schoolname,
                    SchoolLocation = school.Location,
                    Course = school.Course,
                    StartDate =school.StartDate.HasValue? school.StartDate.Value : new DateTime()
                };
                vm.Schools.Add(ed);
            }
            var experiencelist = _context.Experiences.Where(x => x.StudentId == student.Id).ToList();
            vm.Experiences = new List<Experience1>();
            foreach (var experience in experiencelist)
            {
                var ex = new Experience1
                {
                    id = experience.Id,
                    ExperienceName = experience.ExperienceName,
                    ExperienceLocation = experience.Location,
                    Role = experience.Role
                };
                vm.Experiences.Add(ex);
            }
            return View(vm);
        }
     
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}