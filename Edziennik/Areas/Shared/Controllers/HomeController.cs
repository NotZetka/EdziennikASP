using Edziennik.Data;
using Edziennik.Data.Models;
using Edziennik.Models;
using Edziennik.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Edziennik.Controllers
{
    [Area("Shared")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext dbContext;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Message(int id)
        {
            var  message = dbContext.Messages.Include(x=>x.Author).FirstOrDefault(x => x.Id == id);
            message.Opened = true;
            dbContext.SaveChanges();
            return View(message);
        }
        public IActionResult Messages()
        {
            var claim = SharedFunctions.getClaim(User);
            var messages = dbContext.Messages.Include(x=>x.Author).Where(x=>x.ReciverId==claim.Value);
            return View(messages);
        }
        public IActionResult CreateMessage()
        {
            var claim = SharedFunctions.getClaim(User);
            var user = dbContext.ApplicationUsers.FirstOrDefault(x => x.Id == claim.Value);
            var message = new Message() { Author = user, AuthorId = claim.Value };
            var users = dbContext.ApplicationUsers.ToList();
            users.Remove(user);
            ViewBag.Users = users;
            return View(message);
        }
        [HttpPost]
        public IActionResult CreateMessage(Message message)
        {
            if (ModelState.IsValid)
            {
                dbContext.Messages.Add(message);
                dbContext.SaveChanges();
                return RedirectToAction("Messages");
            }
            var claim = SharedFunctions.getClaim(User);
            var user = dbContext.ApplicationUsers.FirstOrDefault(x => x.Id == claim.Value);
            var users = dbContext.ApplicationUsers.ToList();
            users.Remove(user);
            ViewBag.Users = users;
            return View(message);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}