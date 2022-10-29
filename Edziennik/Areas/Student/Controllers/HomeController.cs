using Edziennik.Data;
using Edziennik.Utility;
using Microsoft.AspNetCore.Mvc;

namespace Edziennik.Areas.Student.Controllers
{
    [Area("Student")]
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
            var user = dbContext.Students.FirstOrDefault(x=>x.Id==claim.Value);
            var schoolClass = dbContext.SchoolClasses.FirstOrDefault(x=>x.Id==user.SchoolClassId);
            var lessons = dbContext.Lessons.Where(x=>x.SchoolClass==schoolClass);
            return View(lessons);
        }
    }
}
