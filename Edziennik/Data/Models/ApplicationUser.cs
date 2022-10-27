using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Edziennik.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(30)]
        public string FirstName { get; set; }

        [MaxLength(30)]
        public string SecondName { get; set; }
    }
    public class Student : ApplicationUser
    {
        public List<Mark> Marks { get; set; } = new();
        public List<Behaviour> BehaviourPoints { get; set; } = new();
        public int SchoolClassId { get; set; }
        public SchoolClass SchoolClass { get; set; }
    }
    public class Teacher : ApplicationUser
    {
        public List<Lesson> Lessons { get; set; } = new();
    }
}
