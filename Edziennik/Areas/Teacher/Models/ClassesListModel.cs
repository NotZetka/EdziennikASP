using Microsoft.AspNetCore.Mvc.Rendering;

namespace Edziennik.Areas.Teacher.Models
{
    public class ClassesListModel
    {
        public List<SelectListItem> Classes { get; set; }
        public string ClassId { get; set; }
        public List<StudentsListModel> Students { get; set; }
    }
}
