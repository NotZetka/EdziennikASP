using Microsoft.AspNetCore.Mvc.Rendering;

namespace Edziennik.Areas.Teacher.Models
{
    public class StudentsListModel
    {
        public string ClassId { get; set; }
        public List<SelectListItem> Students { get; set; }
    }
}
