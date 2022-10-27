using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Edziennik.Data.Models
{
    public class Lesson
    {
        public int Id { get; set; }
        [Range(1,40)]
        public int Number { get; set; }
        public string Subject { get; set; }
        public SchoolClass SchoolClass { get; set; }
        public Teacher Teacher { get; set; }
    }
}
