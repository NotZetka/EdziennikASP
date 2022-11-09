

using System.ComponentModel.DataAnnotations;

namespace Edziennik.Models
{
    public class StudentViewModel
    {
        [EmailAddress]
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string SchoolClassId { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
