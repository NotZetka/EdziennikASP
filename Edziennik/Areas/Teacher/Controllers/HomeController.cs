using Edziennik.Data;
using Microsoft.AspNetCore.Mvc;
using Edziennik.Utility;
using Microsoft.EntityFrameworkCore;

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
            return View();
        }
        public IActionResult Student(string id)
        {
            var student = dbContext.Students.FirstOrDefault(x => x.Id == id);
            return View();
        }

        #region API CALLS
        public IActionResult GetStudents()
        {
            var claim = SharedFunctions.getClaim(User);
            var classes = dbContext.Lessons.Where(x => x.Teacher.Id == claim.Value).Select(x => x.SchoolClass.Id);
            var students = dbContext.Students.Include(x => x.SchoolClass).Where(x => classes.Contains(x.SchoolClassId)).Distinct().Select(x => new{ x.FirstName, x.SecondName, classname = x.SchoolClass.Name, x.Id}).ToList();
            return Json(new {data=students});
        }
        #endregion
    }
}
