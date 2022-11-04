using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Edziennik.Data.Models
{
    public class Mark
    {
        public int Id { get; set; }
        [Range(1,6)]
        public int Value { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public string StudentId { get; set; }
        public Student? Student { get; set; }

    }
}
