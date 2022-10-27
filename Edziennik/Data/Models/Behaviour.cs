using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Edziennik.Data.Models
{
    public class Behaviour
    {
        public int Id { get; set; }
        [Range(-100,100)]
        public int Value { get; set; }
    }
}
