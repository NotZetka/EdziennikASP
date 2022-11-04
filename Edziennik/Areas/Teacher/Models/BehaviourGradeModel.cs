using System.ComponentModel.DataAnnotations;

namespace Edziennik.Areas.Teacher.Models
{
    public class BehaviourGradeModel
    {
        [Required]
        public string StudentId { get; set; }
        [Range(-100, 100)]
        [Required]
        public int Value { get; set; }
        [MaxLength(200)]
        [Required]
        public string Comment { get; set; }
    }
}
