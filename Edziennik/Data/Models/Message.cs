using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Edziennik.Data.Models
{
    public class Message
    {
        public int Id { get; set; }

        public bool Opened { get; set; } = false;
        [MaxLength(100)]
        public string Title { get; set; }
        [MaxLength(1000)]
        public string Content { get; set; }
        public string AuthorId { get; set; }
        [ValidateNever]
        public ApplicationUser Author { get; set; }
        public string ReciverId { get; set; }
        [ValidateNever]
        public ApplicationUser Receiver { get; set; }
    }
}
