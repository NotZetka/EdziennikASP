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
}
