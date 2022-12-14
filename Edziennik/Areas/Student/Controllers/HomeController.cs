using Edziennik.Data;
using Edziennik.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Edziennik.Areas.Student.Controllers
{
    [Area("Student")]
    [Authorize(Roles = SD.Role_Student)]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public HomeController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IActionResult Grades()
        {
            var claim = SharedFunctions.getClaim(User);
            var student =  dbContext.Students.Include(x=>x.Marks).FirstOrDefault(x=>x.Id==claim.Value);
            ViewBag.Subjects = dbContext.Subjects.ToList();

            return View(student);
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
