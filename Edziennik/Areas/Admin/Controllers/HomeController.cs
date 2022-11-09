using Edziennik.Data;
using Edziennik.Models;
using Edziennik.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Edziennik.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<IdentityUser> userManager;

        public HomeController(ApplicationDbContext dbContext, UserManager<IdentityUser> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddStudent()
        {
            ViewBag.SchoolClasses = dbContext.SchoolClasses.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
            var student = new StudentViewModel();
            return View(student);
        }
        [HttpPost]
        public IActionResult AddStudent(StudentViewModel studentModel)
        {
            if (ModelState.IsValid)
            {
                var user = dbContext.Users.FirstOrDefault(x => x.NormalizedEmail == studentModel.Email.ToUpper() );
                if(user != null)
                {
                    ViewBag.SchoolClasses = dbContext.SchoolClasses.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
                    ModelState.AddModelError(string.Empty, "Email is already used");
                    return View(studentModel);
                }
                var result = userManager.CreateAsync(new Data.Models.Student
                {
                    Email = studentModel.Email,
                    UserName = studentModel.Email,
                    FirstName = studentModel.FirstName,
                    SecondName = studentModel.SecondName,
                    SchoolClassId = Convert.ToInt32(studentModel.SchoolClassId),
                },studentModel.Password).GetAwaiter().GetResult();
                var student = dbContext.Students.FirstOrDefault(student => student.Email == studentModel.Email);
                userManager.AddToRoleAsync(student, SD.Role_Student);
                return RedirectToAction("Index");
            }
            ViewBag.SchoolClasses = dbContext.SchoolClasses.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
            return View(studentModel);
        }
    }
}
