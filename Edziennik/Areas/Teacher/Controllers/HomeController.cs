using Edziennik.Data;
using Microsoft.AspNetCore.Mvc;
using Edziennik.Utility;
using Microsoft.EntityFrameworkCore;
using Edziennik.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Edziennik.Areas.Teacher.Models;

namespace Edziennik.Areas.Teacher.Controllers
{
    [Area("Teacher")]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public HomeController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IActionResult Plan()
        {
            var claim = SharedFunctions.getClaim(User);
            var lessons = dbContext.Lessons
            .Include(x => x.SchoolClass)
            .Where(x => x.Teacher.Id == claim.Value);
            return View(lessons);
        }
        public IActionResult Students()
        {
            var claim = SharedFunctions.getClaim(User);
            var schoolClasses = dbContext.Lessons
            .Include(x => x.SchoolClass.Students)
            .Where(x => x.Teacher.Id == claim.Value)
            .Select(x => x.SchoolClass)
            .Distinct();
            var classList = new ClassesListModel();
            foreach (var schoolClass in schoolClasses)
            {
                classList.
            }
            return View(schoolClasses);
        }
        
    }
}
