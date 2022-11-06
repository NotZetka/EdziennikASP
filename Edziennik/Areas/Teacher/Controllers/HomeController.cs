using Edziennik.Data;
using Microsoft.AspNetCore.Mvc;
using Edziennik.Utility;
using Microsoft.EntityFrameworkCore;
using Edziennik.Data.Models;
using Microsoft.AspNetCore.Authorization;

namespace Edziennik.Areas.Teacher.Controllers
{
    [Area("Teacher")]
    [Authorize(Roles = SD.Role_Teacher)]
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
            ViewBag.Subjects = dbContext.Subjects.ToList();
            var student = dbContext.Students.Include(x=>x.Marks).Include(x=>x.BehaviourPoints).FirstOrDefault(x => x.Id == id);
            return View(student);
        }
        public IActionResult AddBehaviourGrade(string id)
        {
            var grade = new Behaviour(){ StudentId = id};
            return View(grade);
        }
        [HttpPost]
        public IActionResult AddBehaviourGrade(Behaviour grade)
        {
            ModelState.Remove("id");
            if (ModelState.IsValid)
            {
                var student = dbContext.Students.FirstOrDefault(x => x.Id == grade.StudentId);
                
                student.BehaviourPoints.Add(grade);
                dbContext.SaveChanges();
                return RedirectToAction("Student", new {id=grade.StudentId});
            }
            return View(grade);
        }
        public IActionResult AddMark(string id, string subjectName)
        {
            var subject = dbContext.Subjects.FirstOrDefault(x => x.Name == subjectName);
            var mark = new Mark() { Subject = subject, SubjectId = subject.Id, StudentId = id};
            return View(mark);
        }
        [HttpPost]
        public IActionResult AddMark(Mark mark)
        {
            ModelState.Remove("id");
            if (ModelState.IsValid)
            {
                var student = dbContext.Students.FirstOrDefault(x => x.Id == mark.StudentId);
                student.Marks.Add(mark);
                dbContext.SaveChanges();
                return RedirectToAction("Student", new { id = mark.StudentId });
            }
            return View(mark);
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
