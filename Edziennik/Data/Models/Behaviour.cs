using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Edziennik.Data.Models
{
    public class Behaviour
    {
        public int Id { get; set; }
        [Range(-100,100)]
        public int Value { get; set; }
        [MaxLength(200)]
        public string Comment { get; set; }
        public string StudentId { get; set; }
        [ValidateNever]
        public Student? Student { get; set; }
    }
}
